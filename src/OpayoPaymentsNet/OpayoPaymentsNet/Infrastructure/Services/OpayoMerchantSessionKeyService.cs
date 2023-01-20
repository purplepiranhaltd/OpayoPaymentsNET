using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Domain.Interfaces;
using OpayoPaymentsNet.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Infrastructure.Services
{
    public class OpayoMerchantSessionKeyService : IOpayoMerchantSessionKeyService
    {
        public OpayoMerchantSessionKeyService() 
        { 

        }

        public Result<MerchantSessionKeyResponse> CheckMerchantSessionKey(string merchantSessionKey)
        {
            throw new NotImplementedException();
        }

        public Result<MerchantSessionKeyResponse> CreateMerchantSessionKey(CreateMerchantSessionKeyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
