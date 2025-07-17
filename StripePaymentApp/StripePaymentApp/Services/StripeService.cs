using Stripe;
using StripePaymentApp.Models;

namespace StripePaymentApp.Services
{
    public class StripeService
    {
        public StripeService(IConfiguration configuration)
        {
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
        }

        public PaymentIntent CreatePaymentIntent(CreatePaymentModel model)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = model.Amount,
                Currency = model.Currency,
                PaymentMethodTypes = new List<string> { "card" },
            };

            var service = new PaymentIntentService();
            return service.Create(options);
        }
    }
}
