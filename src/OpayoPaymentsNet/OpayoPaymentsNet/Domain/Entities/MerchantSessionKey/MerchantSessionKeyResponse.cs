using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.MerchantSessionKey
{
    public class MerchantSessionKeyResponse
    {
        public string? MerchantSessionKey { get; set; }
        public string? Expiry { get; set; }
    }
}
