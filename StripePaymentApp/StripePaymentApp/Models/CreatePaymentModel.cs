namespace StripePaymentApp.Models
{
    public class CreatePaymentModel
    {
        public string Currency { get; set; }
        public long Amount { get; set; } // Amount in smallest currency unit
    }
}
