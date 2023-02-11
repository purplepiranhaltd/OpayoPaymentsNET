using Microsoft.Extensions.Options;
using OpayoPaymentsNet.Domain.Builders.Instructions;
using OpayoPaymentsNet.Domain.Builders.Transactions.CreateTransactionRequest;
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

        [Test]
        public async Task RetrieveTransactionAsync_SuccessfullyRetrieved()
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

            var retrieveTransactionResponse = await service.RetrieveTransaction(paymentResponse.Response.TransactionId);

            Assert.NotNull(retrieveTransactionResponse);
            Assert.True(retrieveTransactionResponse.IsSuccess);
            Assert.True(retrieveTransactionResponse.Response?.Status is Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok);
        }

        [Test]
        public async Task VoidInstructionAsync_SuccessfullyVoided()
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

            var voidBuilder = OpayoInstructionRequestBuilder.Create();
            var voidRequest = voidBuilder.AsVoidInstruction().Build();

            var voidResponse = await service.CreateInstruction(paymentResponse.Response.TransactionId, voidRequest.Value);

            Assert.NotNull(voidResponse);
            Assert.True(voidResponse.IsSuccess);
            Assert.True(voidResponse.Response?.InstructionType == Domain.Entities.Instructions.OpayoInstructionType.Void);
            Assert.That(voidResponse.Response?.Date.Date, Is.EqualTo(DateTime.UtcNow.Date));
        }

        [Test]
        public async Task AbortInstructionAsync_SuccessfullyAborted()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var deferredRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var deferredRequest = deferredRequestBuilder
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

            if (deferredRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var deferredResponse = await service.CreateTransaction(deferredRequest.Value);

            if (deferredResponse is null || deferredResponse.IsSuccess is false)
                Assert.Inconclusive("Unable to create payment transaction. There should be another integration test failing that will give more detail.");

            if (deferredResponse.Response?.Status is not Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok)
                Assert.Inconclusive("Invalid response. There should be a unit test failing that will give more detail.");

            var abortBuilder = OpayoInstructionRequestBuilder.Create();
            var abortRequest = abortBuilder.AsAbortInstruction().Build();

            var abortResponse = await service.CreateInstruction(deferredResponse.Response.TransactionId, abortRequest.Value);

            Assert.NotNull(abortResponse);
            Assert.True(abortResponse.IsSuccess);
            Assert.True(abortResponse.Response?.InstructionType == Domain.Entities.Instructions.OpayoInstructionType.Abort);
            Assert.That(abortResponse.Response?.Date.Date, Is.EqualTo(DateTime.UtcNow.Date));
        }

        [Test]
        public async Task ReleaseInstructionAsync_SuccessfullyReleased()
        {
            var msk = await Helpers.GetMerchantSessionKey();

            if (msk is null)
                Assert.Inconclusive("Unable to get Merchant Session Key. There should be another integration test failing that will give more detail.");

            var cardIdentifier = await Helpers.CardIdentifiers.GetCardIdentifier_SUCCESSFUL(msk);

            if (cardIdentifier is null)
                Assert.Inconclusive("Unable to get Card Identifier. There should be another integration test failing that will give more detail.");

            var deferredRequestBuilder = OpayoCreateTransactionRequestBuilder.Create();
            var deferredRequest = deferredRequestBuilder
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

            if (deferredRequest.IsFailure)
                Assert.Inconclusive("Unable to build request. There should be a unit test failing that will give more detail.");

            var service = new OpayoTransactionService(new OpayoRestApiClientService(new HttpClient()), Options.Create(SandboxSettings.Get));
            var deferredResponse = await service.CreateTransaction(deferredRequest.Value);

            if (deferredResponse is null || deferredResponse.IsSuccess is false)
                Assert.Inconclusive("Unable to create payment transaction. There should be another integration test failing that will give more detail.");

            if (deferredResponse.Response?.Status is not Domain.Entities.Transactions.Responses.OpayoTransactionStatus.Ok)
                Assert.Inconclusive("Invalid response. There should be a unit test failing that will give more detail.");

            var releaseBuilder = OpayoInstructionRequestBuilder.Create();
            var releaseRequest = releaseBuilder.AsReleaseInstruction().WithRequiredAmount(100).Build();

            var releaseResponse = await service.CreateInstruction(deferredResponse.Response.TransactionId, releaseRequest.Value);

            Assert.NotNull(releaseResponse);
            Assert.True(releaseResponse.IsSuccess);
            Assert.True(releaseResponse.Response?.InstructionType == Domain.Entities.Instructions.OpayoInstructionType.Release);
            Assert.That(releaseResponse.Response?.Date.Date, Is.EqualTo(DateTime.UtcNow.Date));
        }

        [Test]
        public async Task CancelInstructionAsync_SuccessfullyCancelled()
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

            var cancelBuilder = OpayoInstructionRequestBuilder.Create();
            var cancelRequest = cancelBuilder.AsCancelInstruction().Build();

            var cancelResponse = await service.CreateInstruction(authenticateResponse.Response.TransactionId, cancelRequest.Value);

            Assert.NotNull(cancelResponse);
            Assert.True(cancelResponse.IsSuccess);
            Assert.True(cancelResponse.Response?.InstructionType == Domain.Entities.Instructions.OpayoInstructionType.Cancel);
            Assert.That(cancelResponse.Response?.Date.Date, Is.EqualTo(DateTime.UtcNow.Date));
        }
    }
}