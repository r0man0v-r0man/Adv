using System.Threading.Tasks;
using Adv.API.Models.Payment;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IStripeClient stripeClient;
        public PaymentController(IStripeClient stripeClient)
        {
            this.stripeClient = stripeClient;
        }
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(Checkout checkout)
        {
            if (string.IsNullOrEmpty(checkout.Token)) return BadRequest(false);

            var options = new ChargeCreateOptions
            {
                Amount = 100, // 1 dollar
                Currency = "usd",
                Source = checkout.Token,
                Description = "My First Test Charge (created for API docs)"
            };
            
            var service = new ChargeService(stripeClient);
            var result = await service.CreateAsync(options).ConfigureAwait(false);
            
            return Ok(true);
        }
    }
}
