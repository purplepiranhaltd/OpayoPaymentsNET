using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Instructions;
using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Entities.Transactions.Responses;
using OpayoPaymentsNet.Infrastructure.Models;
using OpayoPaymentsNet.Infrastructure.Settings;
using OpayoPaymentsNet.Interfaces;

namespace OpayoPaymentsNet.Infrastructure.Services
{
    public class OpayoTransactionService : IOpayoTransactionService
    {
        private readonly IOpayoRestApiClientService _opayoRestApiClientService;
        private readonly IOptions<OpayoSettings> _settings;
        private const string TRANSACTIONS_ENDPOINT = "/transactions";
        private const string INSTRUCTIONS_ENDPOINT = "/transactions/{0}/instructions";

        public OpayoTransactionService(IOpayoRestApiClientService opayoRestApiClientService, IOptions<OpayoSettings> settings)
        {
            _opayoRestApiClientService = opayoRestApiClientService;
            _settings = settings;
        }

        public async Task<OpayoResponse<OpayoCreateTransactionResponse>> CreateTransaction(OpayoCreateTransactionRequest request)
        {
            var opayoRequest = new OpayoRequest<OpayoCreateTransactionRequest>(_settings.Value, $"{TRANSACTIONS_ENDPOINT}", HttpMethod.Post, request);
            return await _opayoRestApiClientService.SendAsync(opayoRequest);
        }

        public async Task<OpayoResponse<OpayoRetrieveTransactionResponse>> RetrieveTransaction(string transactionId)
        {
            var opayoRequest = new OpayoRequest<OpayoCreateTransactionResponse>(_settings.Value, $"{TRANSACTIONS_ENDPOINT}/{transactionId}", HttpMethod.Get);
            return await _opayoRestApiClientService.SendAsync(opayoRequest);
        }

        public async Task<OpayoResponse<OpayoInstructionResponse>> CreateInstruction(string transactionId, OpayoInstructionRequest request)
        {
            var opayoRequest = new OpayoRequest<OpayoInstructionRequest>(_settings.Value, string.Format(INSTRUCTIONS_ENDPOINT, transactionId), HttpMethod.Post, request);
            return await _opayoRestApiClientService.SendAsync(opayoRequest);
        }
    }
}
