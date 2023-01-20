using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.MerchantSessionKey;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Infrastructure.Models;
using OpayoPaymentsNet.Infrastructure.Settings;
using OpayoPaymentsNet.Infrastructure.Services;
using System.ComponentModel;

namespace OpayoPaymentsNet.Tests
{
    public class IntegrationTests
    {
        OpayoSettings settings;

        [SetUp]
        public void Setup()
        {
            settings = new OpayoSettings(
                "sandbox",
                "hJYxsw7HLbj40cB8udES8CDRFLhuJ8G54O6rDpUXvE6hYDrria",
                "o2iHSrFybYMZpmWOQMuhsXP52V4fBtpuSDshrKDSWsBY1OiN6hwd9Kb12z4j5Us5u", 
                OpayoEnvironment.Sandbox
            );
        }

        [Test]
        public void CreateMerchantSessionKey_SuccessfullyCreated()
        {
            var service = new OpayoRestApiClientService(new HttpClient());

            var request = new OpayoRequest<CreateMerchantSessionKeyRequest>(
                settings,
                "merchant-session-keys",
                HttpMethod.Post,
                new CreateMerchantSessionKeyRequest() { VendorName = settings.VendorName }
                );

            var response = service.Send(request);

            Assert.That(response.IsSuccess);
            Assert.That(response.HttpStatusCode == System.Net.HttpStatusCode.Created);
            
            var objResponse = new OpayoResponse<MerchantSessionKeyResponse>(response); // TODO: Can we set this up to cast (or return correctly to start with).

            Assert.NotNull(objResponse);
            Assert.NotNull(objResponse.Response);
            Assert.NotNull(objResponse.Response.MerchantSessionKey);
            Assert.That(objResponse.Response.MerchantSessionKey.Length > 0);
        }

        [Test]
        public async Task CreateMerchantSessionKeyAsync_SuccessfullyCreated()
        {
            var service = new OpayoRestApiClientService(new HttpClient());

            var request = new OpayoRequest<CreateMerchantSessionKeyRequest>(
                settings,
                "merchant-session-keys",
                HttpMethod.Post,
                new CreateMerchantSessionKeyRequest() { VendorName = settings.VendorName }
                );

            var response = await service.SendAsync(request);

            Assert.That(response.IsSuccess);
            Assert.That(response.HttpStatusCode == System.Net.HttpStatusCode.Created);

            var objResponse = new OpayoResponse<MerchantSessionKeyResponse>(response); // TODO: Can we set this up to cast (or return correctly to start with).

            Assert.NotNull(objResponse);
            Assert.NotNull(objResponse.Response);
            Assert.NotNull(objResponse.Response.MerchantSessionKey);
            Assert.That(objResponse.Response.MerchantSessionKey.Length > 0);
        }

        [Test]
        public void CreateCardIdentifier_SuccessfullyCreated()
        {
            // MSK
            var mskService = new OpayoRestApiClientService(new HttpClient());
            var mskRequest = new OpayoRequest<CreateMerchantSessionKeyRequest>(
                settings, 
                "merchant-session-keys", 
                HttpMethod.Post, 
                new CreateMerchantSessionKeyRequest() { VendorName = settings.VendorName }
                );
            var mskResponse = mskService.Send(mskRequest);

            var mskResponseObj = new OpayoResponse<MerchantSessionKeyResponse>(mskResponse);

            var msk = mskResponseObj?.Response?.MerchantSessionKey;

            // success card details
            var builder = OpayoCardIdentifierRequestBuilder.Create();
            var requestResult = builder
                .WithCardholderName("SUCCESSFUL")
                .WithCardNumber("4929000000006")
                .WithExpiryDate("1229")
                .WithSecurityCode("123")
                .Build();

            if (requestResult.IsSuccess)
            {
                var identifiersService = new OpayoRestApiClientService(new HttpClient());
                var request = new OpayoRequest<OpayoCardIdentifierRequest>(settings, "card-identifiers", HttpMethod.Post, requestResult.Value, msk);
                var response = identifiersService.Send(request);

                if(response.IsSuccess)
                    Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task CreateCardIdentifierAsync_SuccessfullyCreated()
        {
            // MSK
            var mskService = new OpayoRestApiClientService(new HttpClient());
            var mskRequest = new OpayoRequest<CreateMerchantSessionKeyRequest>(
                settings,
                "merchant-session-keys",
                HttpMethod.Post,
                new CreateMerchantSessionKeyRequest() { VendorName = settings.VendorName }
                );
            var mskResponse = await mskService.SendAsync(mskRequest);

            var mskResponseObj = new OpayoResponse<MerchantSessionKeyResponse>(mskResponse);

            var msk = mskResponseObj?.Response?.MerchantSessionKey;

            // success card details
            var builder = OpayoCardIdentifierRequestBuilder.Create();

            var requestResult = builder
                .WithCardholderName("SUCCESSFUL")
                .WithCardNumber("4929000000006")
                .WithExpiryDate("1229")
                .WithSecurityCode("123")
                .Build();

           if (requestResult.IsSuccess)
           {
                var identifiersService = new OpayoRestApiClientService(new HttpClient());
                var request = new OpayoRequest<OpayoCardIdentifierRequest>(settings, "card-identifiers", HttpMethod.Post, requestResult.Value, msk);
                var response = await identifiersService.SendAsync(request);

                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}