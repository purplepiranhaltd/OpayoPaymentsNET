using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Interfaces
{
    public interface IOpayoMerchantSessionKeyService
    {
        Result<MerchantSessionKeyResponse> CreateMerchantSessionKey(CreateMerchantSessionKeyRequest request);
        Result<MerchantSessionKeyResponse> CheckMerchantSessionKey(string merchantSessionKey);
    }
}
