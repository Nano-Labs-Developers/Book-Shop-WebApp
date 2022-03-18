namespace BookShop.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartBookResponse>>> GetCartBooks(List<CartItem> cartItems);
        
        Task<ServiceResponse<List<CartBookResponse>>> StoreCartItems(List<CartItem> cartItems);
        
        Task<ServiceResponse<int>> GetCartItemsCount();
        
        Task<ServiceResponse<List<CartBookResponse>>> GetDbCartBooks(int? userId = null);
        
        Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
        
        Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);
        
        Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId);
    }
}
