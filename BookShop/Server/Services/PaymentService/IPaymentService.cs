using Stripe.Checkout;

namespace BookShop.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();

        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}
