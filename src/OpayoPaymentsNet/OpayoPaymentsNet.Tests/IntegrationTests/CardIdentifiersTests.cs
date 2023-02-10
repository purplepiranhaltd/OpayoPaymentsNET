using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Infrastructure.Services;
using OpayoPaymentsNet.Interfaces;

namespace OpayoPaymentsNet.Tests.IntegrationTests
{
    public class CardIdentifiersTests
    {
        [Test]
        public async Task CreateMerchantSessionKeyAsync_SuccessfullyCreated()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            IOpayoCardIdentifierService service = new OpayoCardIdentifierService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var builder = OpayoCardIdentifierRequestBuilder.Create();
            var request = builder
                .WithCardholderName("SUCCESSFUL")
                .WithCardNumber("4929000000006")
                .WithExpiryDate("1229")
                .WithSecurityCode("123")
                .Build();

            if (request.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var response = await service.CreateCardIdentifierAsync(msk, request.Value);

            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Response);
        }
    }
}
