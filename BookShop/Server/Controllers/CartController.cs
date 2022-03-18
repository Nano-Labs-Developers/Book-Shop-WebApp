using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("books")]
        public async Task<ActionResult<ServiceResponse<List<CartBookResponse>>>> GetCartBooks(List<CartItem> cartItems)
        {
            var result = await _cartService.GetCartBooks(cartItems);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartBookResponse>>>> StoreCartItems(List<CartItem> cartItems)
        {
            var result = await _cartService.StoreCartItems(cartItems);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
        {
            var result = await _cartService.AddToCart(cartItem);
            return Ok(result);
        }

        [HttpPut("update-quantity")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartItem)
        {
            var result = await _cartService.UpdateQuantity(cartItem);
            return Ok(result);
        }

        [HttpDelete("{bookId}/{bookTypeId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int bookId, int bookTypeId)
        {
            var result = await _cartService.RemoveItemFromCart(bookId, bookTypeId);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
        {
            return await _cartService.GetCartItemsCount();
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CartBookResponse>>>> GetDbCartBooks()
        {
            var result = await _cartService.GetDbCartBooks();
            return Ok(result);
        }
    }
}
