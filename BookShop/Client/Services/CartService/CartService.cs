using Blazored.LocalStorage;

namespace BookShop.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public CartService(ILocalStorageService localStorage, HttpClient http,
            IAuthService authService)
        {
            _localStorage = localStorage;
            _http = http;
            _authService = authService;
        }

        public event Action OnChangeCart;

        public async Task AddToCart(CartItem cartItem)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _http.PostAsJsonAsync("api/cart/add", cartItem);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }

                var sameItem = cart.Find(x => x.BookId == cartItem.BookId &&
                    x.BookTypeId == cartItem.BookTypeId);
                if (sameItem == null)
                {
                    cart.Add(cartItem);
                }
                else
                {
                    sameItem.Quantity += cartItem.Quantity;
                }

                await _localStorage.SetItemAsync("cart", cart);
            }
            await GetCartItemsCount();
        }

        public async Task GetCartItemsCount()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = result.Data;

                await _localStorage.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                await _localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }

            OnChangeCart.Invoke();
        }

        public async Task<List<CartBookResponse>> GetCartBooks()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<CartBookResponse>>>("api/cart");
                return response.Data;
            }
            else
            {
                var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cartItems == null)
                    return new List<CartBookResponse>();
                var response = await _http.PostAsJsonAsync("api/cart/Books", cartItems);
                var cartBooks =
                    await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartBookResponse>>>();
                return cartBooks.Data;
            }

        }

        public async Task RemoveBookFromCart(int bookId, int bookTypeId)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _http.DeleteAsync($"api/cart/{bookId}/{bookTypeId}");
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }

                var cartItem = cart.Find(x => x.BookId == bookId
                    && x.BookTypeId == bookTypeId);
                if (cartItem != null)
                {
                    cart.Remove(cartItem);
                    await _localStorage.SetItemAsync("cart", cart);
                }
            }
        }

        public async Task StoreCartItems(bool emptyLocalCart = false)
        {
            var localCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (localCart == null)
            {
                return;
            }

            await _http.PostAsJsonAsync("api/cart", localCart);

            if (emptyLocalCart)
            {
                await _localStorage.RemoveItemAsync("cart");
            }
        }

        public async Task UpdateQuantity(CartBookResponse book)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var request = new CartItem
                {
                    BookId = book.BookId,
                    Quantity = book.Quantity,
                    BookTypeId = book.BookTypeId
                };
                await _http.PutAsJsonAsync("api/cart/update-quantity", request);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    return;
                }

                var cartItem = cart.Find(x => x.BookId == book.BookId
                    && x.BookTypeId == book.BookTypeId);
                if (cartItem != null)
                {
                    cartItem.Quantity = book.Quantity;
                    await _localStorage.SetItemAsync("cart", cart);
                }
            }
        }
    }
}
