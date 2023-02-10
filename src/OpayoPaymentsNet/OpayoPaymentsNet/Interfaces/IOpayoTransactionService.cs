using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Entities.Transactions.Responses;
using OpayoPaymentsNet.Infrastructure.Models;

namespace OpayoPaymentsNet.Interfaces
{
    public interface IOpayoTransactionService
    {
        Task<OpayoResponse<OpayoCreateTransactionResponse>> CreateTransaction(OpayoCreateTransactionRequest request);
    }
}