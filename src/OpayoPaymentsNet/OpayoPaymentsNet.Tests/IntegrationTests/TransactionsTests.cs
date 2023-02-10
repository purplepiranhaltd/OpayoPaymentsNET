using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Builders.Transactions;
using OpayoPaymentsNet.Domain.Builders.Transactions.Extensions;
using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Infrastructure.Services;
using OpayoPaymentsNet.Interfaces;

namespace OpayoPaymentsNet.Tests.IntegrationTests
{
    public class TransactionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreatePaymentTransactionAsync_SuccessfullyCreated()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var builder = OpayoCreateTransactionRequestBuilder.Create();

            var request = builder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsPaymentTransaction()
                .WithRequiredCurrency("GBP")
                .WithRequiredPaymentMethod(new OpayoPaymentMethod() { Card = new OpayoCard() { CardIdentifier = cardIdentifier.CardIdentifier, MerchantSessionKey = msk, Reusable = false, Save = false } })
                .WithRequiredCustomerFirstName("Tommy")
                .WithRequiredCustomerLastName("Tester")
                .WithRequiredBillingAddress(new OpayoBillingAddress() { Address1 = "88", PostalCode = "412", City = "London", Country = "GB" })
                .Build();

            if (request.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var response = await service.CreateTransaction(request.Value);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.True(response.Response?.Status == Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok);
        }

        [Test]
        public async Task CreateDeferredTransactionAsync_SuccessfullyCreated()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var builder = OpayoCreateTransactionRequestBuilder.Create();
            var request = builder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsDeferredTransaction()
                .WithRequiredCurrency("GBP")
                .WithRequiredPaymentMethod(new OpayoPaymentMethod() { Card = new OpayoCard() { CardIdentifier = cardIdentifier.CardIdentifier, MerchantSessionKey = msk, Reusable = false, Save = false } })
                .WithRequiredCustomerFirstName("Tommy")
                .WithRequiredCustomerLastName("Tester")
                .WithRequiredBillingAddress(new OpayoBillingAddress() { Address1 = "88", PostalCode = "412", City = "London", Country = "GB" })
                .Build();

            if (request.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var response = await service.CreateTransaction(request.Value);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.True(response.Response?.Status is Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok);
        }

        [Test]
        public async Task CreateAuthenticateTransactionAsync_SuccessfullyCreated()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var builder = OpayoCreateTransactionRequestBuilder.Create();
            var request = builder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsAuthenticateTransaction()
                .WithRequiredCurrency("GBP")
                .WithRequiredPaymentMethod(new OpayoPaymentMethod() { Card = new OpayoCard() { CardIdentifier = cardIdentifier.CardIdentifier, MerchantSessionKey = msk, Reusable = false, Save = false } })
                .WithRequiredCustomerFirstName("Tommy")
                .WithRequiredCustomerLastName("Tester")
                .WithRequiredBillingAddress(new OpayoBillingAddress() { Address1 = "88", PostalCode = "412", City = "London", Country = "GB" })
                .Build();

            if (request.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var response = await service.CreateTransaction(request.Value);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.True(response.Response?.Status is Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Registered);
        }

        [Test]
        public async Task CreateRepeatTransactionAsync_SuccessfullyCreated()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var paymentRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var paymentRequest = paymentRequestBuilder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsPaymentTransaction()
                .WithRequiredCurrency("GBP")
                .WithRequiredPaymentMethod(new OpayoPaymentMethod() { Card = new OpayoCard() { CardIdentifier = cardIdentifier.CardIdentifier, MerchantSessionKey = msk, Reusable = false, Save = false } })
                .WithRequiredCustomerFirstName("Tommy")
                .WithRequiredCustomerLastName("Tester")
                .WithRequiredBillingAddress(new OpayoBillingAddress() { Address1 = "88", PostalCode = "412", City = "London", Country = "GB" })
                .Build();

            if (paymentRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var paymentResponse = await service.CreateTransaction(paymentRequest.Value);

            if (paymentResponse is null || paymentResponse.IsSuccess is false)
                    Assert.Inconclusive("Unable to create payment transaction. There should be another integration test failing that will give more detail.");

            if (paymentResponse.Response?.Status is not Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok)
                Assert.Inconclusive("Invalid response. There should be a unit test failing that will give more detail.");

            var repeatRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var repeatRequest = repeatRequestBuilder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsRepeatTransaction()
                .WithRequiredReferenceTransactionId(paymentResponse.Response.TransactionId)
                .WithRequiredCurrency("GBP")
                .Build();

            if (repeatRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var repeatResponse = await service.CreateTransaction(repeatRequest.Value);

            Assert.NotNull(repeatResponse);
            Assert.True(repeatResponse.IsSuccess);
            Assert.True(repeatResponse.Response?.Status is Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok);
        }

        [Test]
        public async Task CreateAuthoriseTransactionAsync_SuccessfullyCreated()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var authenticateRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var authenticateRequest = authenticateRequestBuilder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsAuthenticateTransaction()
                .WithRequiredCurrency("GBP")
                .WithRequiredPaymentMethod(new OpayoPaymentMethod() { Card = new OpayoCard() { CardIdentifier = cardIdentifier.CardIdentifier, MerchantSessionKey = msk, Reusable = false, Save = false } })
                .WithRequiredCustomerFirstName("Tommy")
                .WithRequiredCustomerLastName("Tester")
                .WithRequiredBillingAddress(new OpayoBillingAddress() { Address1 = "88", PostalCode = "412", City = "London", Country = "GB" })
                .Build();

            if (authenticateRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var authenticateResponse = await service.CreateTransaction(authenticateRequest.Value);

            if (authenticateResponse is null || authenticateResponse.IsSuccess is false)
                Assert.Inconclusive("Unable to create payment transaction. There should be another integration test failing that will give more detail.");

            if (authenticateResponse.Response?.Status is not Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Registered)
                Assert.Inconclusive("Invalid response. There should be a unit test failing that will give more detail.");

            var authoriseRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var authoriseRequest = authoriseRequestBuilder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsAuthoriseTransaction()
                .WithRequiredReferenceTransactionId(authenticateResponse.Response.TransactionId)
                .Build();

            if (authoriseRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var authoriseResponse = await service.CreateTransaction(authoriseRequest.Value);

            Assert.NotNull(authoriseResponse);
            Assert.True(authoriseResponse.IsSuccess);
            Assert.True(authoriseResponse.Response?.Status is Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok);
        }

        [Test]
        public async Task CreateRefundTransactionAsync_SuccessfullyCreated()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var paymentRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var paymentRequest = paymentRequestBuilder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsPaymentTransaction()
                .WithRequiredCurrency("GBP")
                .WithRequiredPaymentMethod(new OpayoPaymentMethod() { Card = new OpayoCard() { CardIdentifier = cardIdentifier.CardIdentifier, MerchantSessionKey = msk, Reusable = false, Save = false } })
                .WithRequiredCustomerFirstName("Tommy")
                .WithRequiredCustomerLastName("Tester")
                .WithRequiredBillingAddress(new OpayoBillingAddress() { Address1 = "88", PostalCode = "412", City = "London", Country = "GB" })
                .Build();

            if (paymentRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var paymentResponse = await service.CreateTransaction(paymentRequest.Value);

            if (paymentResponse is null || paymentResponse.IsSuccess is false)
                Assert.Inconclusive("Unable to create payment transaction. There should be another integration test failing that will give more detail.");

            if (paymentResponse.Response?.Status is not Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok)
                Assert.Inconclusive("Invalid response. There should be a unit test failing that will give more detail.");

            var refundRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var refundRequest = refundRequestBuilder
                .WithRequiredVendorTxCode(Guid.NewGuid().ToString())
                .WithRequiredDescription("Integration Test Transaction")
                .WithRequiredAmount(100)
                .AsRefundTransaction()
                .WithRequiredReferenceTransactionId(paymentResponse.Response.TransactionId)
                .Build();

            if (refundRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var refundResponse = await service.CreateTransaction(refundRequest.Value);

            Assert.NotNull(refundResponse);
            Assert.True(refundResponse.IsSuccess);
            Assert.True(refundResponse.Response?.Status is Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok);
        }
    }
}