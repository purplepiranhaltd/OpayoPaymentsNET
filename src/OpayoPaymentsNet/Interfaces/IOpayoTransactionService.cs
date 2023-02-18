using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Instructions;
using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Entities.Transactions.Responses;
using OpayoPaymentsNet.Infrastructure.Models;

namespace OpayoPaymentsNet.Interfaces
{
    public interface IOpayoTransactionService
    {
        Task<OpayoResponse<OpayoCreateTransactionResponse>> CreateTransaction(OpayoCreateTransactionRequest request);
        Task<OpayoResponse<OpayoRetrieveTransactionResponse>> RetrieveTransaction(string transactionId);
        Task<OpayoResponse<OpayoInstructionResponse>> CreateInstruction(string transactionId, OpayoInstructionRequest request);
        Task<OpayoResponse<OpayoCreateTransactionResponse>> Create3DSecureChallengeResponse(string transactionId, Opayo3DSecureChallengeResponseRequest request);
    }
}