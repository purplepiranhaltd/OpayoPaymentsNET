using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.CardIdentifiers
{
    public class OpayoCreateIdentifierResponse
    {
        public string CardIdentifier { get; set; }
        public string Expiry { get; set; }
        public string CardType { get; set; }
    }
}
