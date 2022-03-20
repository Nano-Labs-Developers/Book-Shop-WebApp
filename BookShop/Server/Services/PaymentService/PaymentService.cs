using Stripe;
using Stripe.Checkout;

namespace BookShop.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;

        const string secret = "whsec_cq1WH9CX9U1zxU9EpbBVvWOhfb6e5ysR";

        public PaymentService(ICartService cartService, IAuthService authService, IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "sk_test_51KdiFICYsRhvjKeMUJOxp9lZ7MNBveDdZFOcwKXtQVeJjvYa7vKraCJCzoMZyUzEWuFoXOdq9cPOYD2sDEieF4oh00m5y2DeP0";

            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }

        public async Task<Session> CreateCheckoutSession()
        {
            var books = (await _cartService.GetDbCartBooks()).Data;
            var lineItems = new List<SessionLineItemOptions>();

            books.ForEach(book => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = book.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = book.Title,
                        Images = new List<string> { book.ImageUrl }
                    }
                },
                Quantity = book.Quantity
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "US" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7207/OrderSuccess",
                CancelUrl = "https://localhost:7207/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["Stripe-Signature"],
                        secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = e.Message };
            }
        }
    }
}
