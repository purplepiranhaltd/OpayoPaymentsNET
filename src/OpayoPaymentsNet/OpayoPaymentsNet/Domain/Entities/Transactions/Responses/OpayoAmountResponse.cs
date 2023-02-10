using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoAmountResponse
    {
        public int TotalAmount { get; set; }
        public int SaleAmount { get; set; }
        public int SurchargeAmount { get; set; }
    }
}
