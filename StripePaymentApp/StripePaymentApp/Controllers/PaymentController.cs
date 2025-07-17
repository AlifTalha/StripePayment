using Microsoft.AspNetCore.Mvc;
using StripePaymentApp.Models;
using StripePaymentApp.Services;

namespace StripePaymentApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StripeService _stripeService;
        private readonly IConfiguration _config;

        public PaymentController(StripeService stripeService, IConfiguration config)
        {
            _stripeService = stripeService;
            _config = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.PublishableKey = _config["Stripe:PublishableKey"];
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreatePaymentIntent([FromBody] CreatePaymentModel model)
        {
            var intent = _stripeService.CreatePaymentIntent(model);
            return Json(new { clientSecret = intent.ClientSecret });
        }
    }
}
