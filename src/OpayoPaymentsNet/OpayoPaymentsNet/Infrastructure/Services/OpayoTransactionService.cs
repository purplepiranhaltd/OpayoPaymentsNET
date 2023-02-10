﻿using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
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

        ////public async Task<OpayoResponse<OpayoCreateIdentifierResponse>> RetrieveTransaction(string transactionId)
        ////{
        ////    var opayoRequest = new OpayoRequest(_settings.Value, $"{CARD_IDENTIFIERS_ENDPOINT}/{transactionId}", HttpMethod.Get);
        ////    return await _opayoRestApiClientService.SendAsync(opayoRequest);
        ////}
    }
}