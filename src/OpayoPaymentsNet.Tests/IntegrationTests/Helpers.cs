using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Infrastructure.Services;
using OpayoPaymentsNet.Infrastructure.Settings;
using OpayoPaymentsNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpayoPaymentsNet.Tests.IntegrationTests.Helpers;

namespace OpayoPaymentsNet.Tests.IntegrationTests
{
    /// <summary>
    /// These helpers are for use in integration tests in order to get the required parameters for the method under test.
    /// They should not be used for testing the methods within them.
    /// If they return null then the test should return an inconclusive result as it means that another test should be failing.
    /// </summary>
    public static class Helpers
    {
        public static async Task<string?> GetMerchantSessionKey(OpayoSettings? settings = null)
        {
            if (settings is null)
                settings = SandboxSettings.Get;

            try
            {
                IOpayoMerchantSessionKeyService service = new OpayoMerchantSessionKeyService(new OpayoRestApiClientService(new HttpClient()), Options.Create(settings));
                var response = await service.CreateMerchantSessionKeyAsync();
                return response?.Response?.MerchantSessionKey;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static class CardIdentifiers
        {
            public static async Task<OpayoCreateIdentifierResponse?> GetCardIdentifier_SUCCESSFUL(string merchantSessionKey, OpayoSettings? settings = null)
            {
                return await GetCardIdentifier(merchantSessionKey, "SUCCESSFUL", "4929000000006", "1229", "123");
            }

            public static async Task<OpayoCreateIdentifierResponse?> GetCardIdentifier_NOTAUTH(string merchantSessionKey, OpayoSettings? settings = null)
            {
                return await GetCardIdentifier(merchantSessionKey, "NOTAUTH", "4929000000006", "1229", "123");
            }

            public static async Task<OpayoCreateIdentifierResponse?> GetCardIdentifier_CHALLENGE(string merchantSessionKey, OpayoSettings? settings = null)
            {
                return await GetCardIdentifier(merchantSessionKey, "CHALLENGE", "4929000000006", "1229", "123");
            }

            public static async Task<OpayoCreateIdentifierResponse?> GetCardIdentifier_PROOFATTEMPT(string merchantSessionKey, OpayoSettings? settings = null)
            {
                return await GetCardIdentifier(merchantSessionKey, "PROOFATTEMPT", "4929000000006", "1229", "123");
            }

            public static async Task<OpayoCreateIdentifierResponse?> GetCardIdentifier_TECHDIFFICULTIES(string merchantSessionKey, OpayoSettings? settings = null)
            {
                return await GetCardIdentifier(merchantSessionKey, "TECHDIFFICULTIES", "4929000000006", "1229", "123");
            }

            public static async Task<OpayoCreateIdentifierResponse?> GetCardIdentifier_ERROR(string merchantSessionKey, OpayoSettings? settings = null)
            {
                return await GetCardIdentifier(merchantSessionKey, "ERROR", "4929000000006", "1229", "123");
            }

            private static async Task<OpayoCreateIdentifierResponse?> GetCardIdentifier(string merchantSessionKey, string nameOnCard, string cardNumber, string expiryMMYY, string securityCode, OpayoSettings? settings = null)
            {
                if (settings is null)
                    settings = SandboxSettings.Get;

                try
                {
                    IOpayoCardIdentifierService service = new OpayoCardIdentifierService(new OpayoRestApiClientService(new HttpClient()), Options.Create(settings));
                    var builder = OpayoCreateCardIdentifierRequestBuilder.Create();
                    var request = builder
                        .WithCardholderName(nameOnCard)
                        .WithCardNumber(cardNumber)
                        .WithExpiryDate(expiryMMYY)
                        .WithSecurityCode(securityCode)
                        .Build();

                    if (request.IsFailure)
                        Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

                    var response = await service.CreateCardIdentifierAsync(merchantSessionKey, request.Value);
                    return response?.Response;
                }
                catch (Exception) { return null; }
            }
        }
    }
}
