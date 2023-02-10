using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Infrastructure.Models;
using OpayoPaymentsNet.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Interfaces
{
    public interface IOpayoMerchantSessionKeyService
    {
        Task<OpayoResponse<OpayoMerchantSessionKeyResponse>> CreateMerchantSessionKeyAsync();
        Task<OpayoResponse<OpayoMerchantSessionKeyResponse>> CheckMerchantSessionKeyAsync(string merchantSessionKey);
    }
}
