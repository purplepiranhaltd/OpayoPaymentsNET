using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Errors;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Tests.UnitTests
{
    public class PaymentMethodValidatorUnitTests
    {
        PaymentMethodValidator validator;
        OpayoCard dummyCard;
        OpayoApplePay dummyApplePay;

        [SetUp]
        public void Setup()
        {
            validator = new PaymentMethodValidator();
            dummyCard = new OpayoCard() { MerchantSessionKey = Guid.NewGuid().ToString(), CardIdentifier = Guid.NewGuid().ToString() };
            dummyApplePay = new OpayoApplePay() { SessionValidationToken = "X", ClientIpAddress = "127.0.0.1", Payload = "X" };
        }

        [Test]
        public void PaymentMethod_WithValidDetails_Card()
        {
            var paymentMethod = new OpayoPaymentMethod() { 
                 Card = dummyCard
            };

            var errors = validator.GetErrors(paymentMethod);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void PaymentMethod_WithValidDetails_ApplePay()
        {
            var paymentMethod = new OpayoPaymentMethod()
            {
                ApplePay = dummyApplePay
            };

            var errors = validator.GetErrors(paymentMethod);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void PaymentMethod_WithInvalidDetails_NoPaymentMethod()
        {
            var paymentMethod = new OpayoPaymentMethod()
            {
            };

            var errors = validator.GetErrors(paymentMethod);
            Assert.That(errors.Count(), Is.EqualTo(1));
        }

        [Test]
        public void PaymentMethod_WithInvalidDetails_BothPaymentMethods()
        {
            var paymentMethod = new OpayoPaymentMethod()
            {
                ApplePay = dummyApplePay,
                Card = dummyCard
            };

            var errors = validator.GetErrors(paymentMethod);
            Assert.That(errors.Count(), Is.EqualTo(1));
        }

        /// <summary>
        /// This tests that the errors are passed correctly from the CardValidator to the PaymentMethodValidator
        /// </summary>
        [Test]
        public void PaymentMethod_WithInvalidDetails_InvalidCard()
        {
            var paymentMethod = new OpayoPaymentMethod()
            {
                Card = new OpayoCard()
                {
                }
            };

            var errors = validator.GetErrors(paymentMethod);
            Assert.That(errors.Count(), Is.EqualTo(2));
        }

    }
}