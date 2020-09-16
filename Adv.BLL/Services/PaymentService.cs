using System;
using System.Threading.Tasks;
using Adv.BLL.Interfaces;
using Stripe;

namespace Adv.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ChargeService chargeService;
        public PaymentService(IStripeClient stripeClient)
        {
            chargeService = new ChargeService(stripeClient);
        }

        public async Task<bool> CheckoutAsync(string stripeToken)
        {
            var options = new ChargeCreateOptions
            {
                Amount = 100, // 1 dollar
                Currency = "usd",
                Source = stripeToken,
                Description = "Payment for advert on halupa.by"
            };
            var result = await chargeService.CreateAsync(options).ConfigureAwait(false);
                
            return result.Paid;
        }
    }
}
