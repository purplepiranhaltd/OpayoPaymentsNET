using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Tests.UnitTests
{
    public class BillingAddressValidatorUnitTests
    {
        BillingAddressValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new BillingAddressValidator();
        }

        [Test]
        public void BillingAddress_WithValidDetails()
        {
            var address = new OpayoBillingAddress() { 
                Address1 = "1 The Road",
                City = "London",
                PostalCode = "EC2A 1AA",
                Country = "GB"

            };
            var errors = validator.GetErrors(address);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void BillingAddress_WithInvalidDetails_MissingAddress1()
        {
            var address = new OpayoBillingAddress()
            {
                City = "London",
                PostalCode = "EC2A 1AA",
                Country = "GB"

            };
            var errors = validator.GetErrors(address);
            Assert.That(errors.Count(), Is.EqualTo(1));
        }

        public void BillingAddress_WithInvalidDetails_City()
        {
            var address = new OpayoBillingAddress()
            {
                Address1 = "1 The Road",
                PostalCode = "EC2A 1AA",
                Country = "GB"

            };
            var errors = validator.GetErrors(address);
            Assert.That(errors.Count(), Is.EqualTo(1));
        }

        public void BillingAddress_WithInvalidDetails_Country()
        {
            var address = new OpayoBillingAddress()
            {
                Address1 = "1 The Road",
                City = "London",
                PostalCode = "EC2A 1AA",
            };
            var errors = validator.GetErrors(address);
            Assert.That(errors.Count(), Is.EqualTo(1));
        }
    }
}