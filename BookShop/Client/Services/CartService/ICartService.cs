namespace BookShop.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChangeCart;

        Task AddToCart(CartItem cartItem);

        Task<List<CartBookResponse>> GetCartBooks();

        Task RemoveBookFromCart(int bookId, int bookTypeId);

        Task UpdateQuantity(CartBookResponse book);

        Task StoreCartItems(bool emptyLocalCart);

        Task GetCartItemsCount();
    }
}
