namespace BookShop.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext context,
            ICartService cartService,
            IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponse>();
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.BookType)
                .Where(o => o.UserId == _authService.GetUserId() && o.Id == orderId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponse
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Books = new List<OrderDetailsBookResponse>()
            };

            order.OrderItems.ForEach(item =>
            orderDetailsResponse.Books.Add(new OrderDetailsBookResponse
            {
                BookId = item.BookId,
                ImageUrl = item.Book.ImageURL,
                BookType = item.BookType.Name,
                Quantity = item.Quantity,
                Title = item.Book.Title,
                TotalPrice = item.TotalPrice
            }));

            response.Data = orderDetailsResponse;

            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponse
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Book = o.OrderItems.Count > 1 ?
                    $"{o.OrderItems.First().Book.Title} and" +
                    $" {o.OrderItems.Count - 1} more..." :
                    o.OrderItems.First().Book.Title,
                BookImageURL = o.OrderItems.First().Book.ImageURL
            }));

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder(int userId)
        {
            var books = (await _cartService.GetDbCartBooks(userId)).Data;
            decimal totalPrice = 0;
            books.ForEach(book => totalPrice += book.Price * book.Quantity);

            var orderItems = new List<OrderItem>();
            books.ForEach(book => orderItems.Add(new OrderItem
            {
                BookId = book.BookId,
                BookTypeId = book.BookTypeId,
                Quantity = book.Quantity,
                TotalPrice = book.Price * book.Quantity
            }));

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems
                .Where(ci => ci.UserId == userId));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
