using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Infrastructure.Services;
using OpayoPaymentsNet.Interfaces;

namespace OpayoPaymentsNet.Tests.IntegrationTests
{
    public class MerchantSessionKeysTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateMerchantSessionKeyAsync_SuccessfullyCreated()
        {
            IOpayoMerchantSessionKeyService service = new OpayoMerchantSessionKeyService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var response = await service.CreateMerchantSessionKeyAsync();

            Assert.NotNull(response);
            Assert.That(response.IsSuccess);
            Assert.That(response.HttpStatusCode == System.Net.HttpStatusCode.Created);
            Assert.NotNull(response.Response);
            Assert.NotNull(response.Response.MerchantSessionKey);
            Assert.That(response.Response.MerchantSessionKey.Length > 0);
            Assert.NotNull(response.Response.Expiry);
            Assert.That(response.Response.Expiry.Length > 0);
        }

        [Test]
        public async Task CreateMerchantSessionKeyAsync_SuccessfullyChecked()
        {
            // setup MSK - this could fail and is checked in a different test
            // if we don't get an MSK we simply return as inconclusive result as it's
            // impossible to continue the test
            string? msk = null;
            string? expiry = null;
            try
            {
                IOpayoMerchantSessionKeyService service = new OpayoMerchantSessionKeyService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
                var response = await service.CreateMerchantSessionKeyAsync();

                if (
                    response is not null &&
                    response.IsSuccess &&
                    response.HttpStatusCode is System.Net.HttpStatusCode.Created &&
                    response.Response is not null &&
                    response.Response.MerchantSessionKey is not null &&
                    response.Response.MerchantSessionKey.Length > 0 &&
                    response.Response.Expiry is not null &&
                    response.Response.Expiry.Length > 0
                    )
                {
                    msk = response.Response.MerchantSessionKey;
                    expiry = response.Response.Expiry;
                }
            }
            catch (Exception ex)
            {
            }

            if (msk is null || expiry is null)
                Assert.Inconclusive($"Could not create initial MSK, check whether test CreateMerchantSessionKeyAsync_SuccessfullyCreated has passed");

            IOpayoMerchantSessionKeyService service2 = new OpayoMerchantSessionKeyService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var response2 = await service2.CheckMerchantSessionKeyAsync(msk);

            Assert.NotNull(response2);
            Assert.That(response2.IsSuccess);
            Assert.That(response2.HttpStatusCode == System.Net.HttpStatusCode.OK);
            Assert.NotNull(response2.Response);
            Assert.That(!string.IsNullOrEmpty(response2.Response.MerchantSessionKey));
            Assert.That(!string.IsNullOrEmpty(response2.Response.Expiry));

            Assert.That(response2.Response.MerchantSessionKey == msk);
            Assert.That(response2.Response.Expiry == expiry);
        }
    }
}