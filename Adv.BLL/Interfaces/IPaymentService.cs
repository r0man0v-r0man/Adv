using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        /// Checkout
        /// </summary>
        /// <param name="stripeToken">token from stripe.com</param>
        /// <returns></returns>
        Task<bool> CheckoutAsync(string stripeToken);
    }
}
