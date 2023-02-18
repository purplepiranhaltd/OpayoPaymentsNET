using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoPayPalResponse
    {
        /// <summary>
        /// The PayPal URL to redirect your customer to.
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// The PayPal order ID.
        /// </summary>
        public string OrderId { get; set; }
    }
}
