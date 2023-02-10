using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.CardIdentifiers
{
    public record OpayoLinkCardIdentifierRequest(string SecurityCode)
    {
    }
}
