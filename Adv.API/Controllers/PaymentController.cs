using System;
using System.Threading.Tasks;
using Adv.API.Models.Payment;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(Checkout checkout)
        {
            if (string.IsNullOrEmpty(checkout.Token)) return BadRequest(false);
            try
            {
                var result = await paymentService.CheckoutAsync(checkout.Token).ConfigureAwait(false);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
            
        }
    }
}
