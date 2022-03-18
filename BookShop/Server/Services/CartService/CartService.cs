namespace BookShop.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public CartService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<CartBookResponse>>> GetCartBooks(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartBookResponse>>
            {
                Data = new List<CartBookResponse>()
            };

            foreach (var item in cartItems)
            {
                var book = await _context.Books
                    .Where(p => p.Id == item.BookId)
                    .FirstOrDefaultAsync();

                if (book == null)
                {
                    continue;
                }

                var bookVariant = await _context.BookVariants
                    .Where(v => v.BookId == item.BookId
                        && v.BookTypeId == item.BookTypeId)
                    .Include(v => v.BookType)
                    .FirstOrDefaultAsync();

                if (bookVariant == null)
                {
                    continue;
                }

                var cartBook = new CartBookResponse
                {
                    BookId = book.Id,
                    Title = book.Title,
                    ImageUrl = book.ImageURL,
                    Price = bookVariant.Price,
                    BookType = bookVariant.BookType.Name,
                    BookTypeId = bookVariant.BookTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartBook);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CartBookResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _context.CartItems.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetDbCartBooks();
        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            var count = (await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count;
            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<List<CartBookResponse>>> GetDbCartBooks(int? userId = null)
        {
            if (userId == null)
                userId = _authService.GetUserId();

            return await GetCartBooks(await _context.CartItems
                .Where(ci => ci.UserId == userId).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();

            var sameItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.BookId == cartItem.BookId &&
                ci.BookTypeId == cartItem.BookTypeId && ci.UserId == cartItem.UserId);
            if (sameItem == null)
            {
                _context.CartItems.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.BookId == cartItem.BookId &&
                ci.BookTypeId == cartItem.BookTypeId && ci.UserId == _authService.GetUserId());
            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }

            dbCartItem.Quantity = cartItem.Quantity;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int bookId, int bookTypeId)
        {
            var dbCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.BookId == bookId &&
                ci.BookTypeId == bookTypeId && ci.UserId == _authService.GetUserId());
            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }

            _context.CartItems.Remove(dbCartItem);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
