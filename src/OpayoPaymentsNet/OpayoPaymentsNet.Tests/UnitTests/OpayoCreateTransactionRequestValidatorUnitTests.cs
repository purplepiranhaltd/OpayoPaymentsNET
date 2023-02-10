using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Enums;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;
using static OpayoPaymentsNet.Tests.IntegrationTests.Helpers;

namespace OpayoPaymentsNet.Tests.UnitTests
{
    public class OpayoCreateTransactionRequestValidatorUnitTests
    {
        OpayoCreateTransactionRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new OpayoCreateTransactionRequestValidator();
        }

        [Test]
        public void Payment_WithValidDetails()
        {
            var transaction = new OpayoCreateTransactionRequest() {
                // required fields for all transaction
                VendorTxCode = "TestPaymentTransaction",
                Description = "Testing a payment transaction",
                Amount = 100,
                TransactionType = TransactionType.Payment,

                // required fields for payment transactions
                Currency = "GBP",
                PaymentMethod = new OpayoPaymentMethod() { 
                    Card = new OpayoCard()
                    {
                        CardIdentifier = Guid.NewGuid().ToString(),
                        MerchantSessionKey = Guid.NewGuid().ToString(),
                    }
                },
                CustomerFirstName = "Thomas",
                CustomerLastName = "Tester",
                BillingAddress = new OpayoBillingAddress()
                {
                    Address1 = "1 The Road",
                    City = "London",
                    PostalCode = "EC2A 1AA",
                    Country = "GB"
                }
            };

            var errors = validator.GetErrors(transaction);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Deferred_WithValidDetails()
        {
            var transaction = new OpayoCreateTransactionRequest()
            {
                // required fields for all transaction
                VendorTxCode = "TestDeferredTransaction",
                Description = "Testing a deferred transaction",
                Amount = 100,
                TransactionType = TransactionType.Deferred,

                // required fields for deferred transactions
                Currency = "GBP",
                PaymentMethod = new OpayoPaymentMethod()
                {
                    Card = new OpayoCard()
                    {
                        CardIdentifier = Guid.NewGuid().ToString(),
                        MerchantSessionKey = Guid.NewGuid().ToString(),
                    }
                },
                CustomerFirstName = "Thomas",
                CustomerLastName = "Tester",
                BillingAddress = new OpayoBillingAddress()
                {
                    Address1 = "1 The Road",
                    City = "London",
                    PostalCode = "EC2A 1AA",
                    Country = "GB"
                }
            };

            var errors = validator.GetErrors(transaction);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Authenticate_WithValidDetails()
        {
            var transaction = new OpayoCreateTransactionRequest()
            {
                // required fields for all transaction
                VendorTxCode = "TestAuthenticateTransaction",
                Description = "Testing an authenticate transaction",
                Amount = 100,
                TransactionType = TransactionType.Authenticate,

                // required fields for authenticate transactions
                Currency = "GBP",
                PaymentMethod = new OpayoPaymentMethod()
                {
                    Card = new OpayoCard()
                    {
                        CardIdentifier = Guid.NewGuid().ToString(),
                        MerchantSessionKey = Guid.NewGuid().ToString(),
                    }
                },
                CustomerFirstName = "Thomas",
                CustomerLastName = "Tester",
                BillingAddress = new OpayoBillingAddress()
                {
                    Address1 = "1 The Road",
                    City = "London",
                    PostalCode = "EC2A 1AA",
                    Country = "GB"
                }
            };

            var errors = validator.GetErrors(transaction);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Repeat_WithValidDetails()
        {
            var transaction = new OpayoCreateTransactionRequest()
            {
                // required fields for all transaction
                VendorTxCode = "TestRepeatTransaction",
                Description = "Testing an authenticate transaction",
                Amount = 100,
                TransactionType = TransactionType.Repeat,

                // required fields for repeat transactions
                ReferenceTransactionId = Guid.NewGuid().ToString(),
                Currency = "GBP"
            };

            var errors = validator.GetErrors(transaction);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Authorise_WithValidDetails()
        {
            var transaction = new OpayoCreateTransactionRequest()
            {
                // required fields for all transaction
                VendorTxCode = "TestAuthoriseTransaction",
                Description = "Testing an authorise transaction",
                Amount = 100,
                TransactionType = TransactionType.Authorise,

                // required fields for repeat transactions
                ReferenceTransactionId = Guid.NewGuid().ToString()
            };

            var errors = validator.GetErrors(transaction);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Refund_WithValidDetails()
        {
            var transaction = new OpayoCreateTransactionRequest()
            {
                // required fields for all transaction
                VendorTxCode = "TestRefundTransaction",
                Description = "Testing an refund transaction",
                Amount = 100,
                TransactionType = TransactionType.Refund,

                // required fields for repeat transactions
                ReferenceTransactionId = Guid.NewGuid().ToString()
            };

            var errors = validator.GetErrors(transaction);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }
    }
}