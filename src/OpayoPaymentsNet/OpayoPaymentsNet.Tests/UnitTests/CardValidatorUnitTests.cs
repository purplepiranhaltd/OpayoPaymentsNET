using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;
using OpayoPaymentsNet.Domain.Validators;

namespace OpayoPaymentsNet.Tests.UnitTests
{
    public class CardValidatorUnitTests
    {
        CardValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new CardValidator();
        }

        [Test]
        public void Card_WithValidDetails()
        {
            var card = new OpayoCard() { MerchantSessionKey = Guid.NewGuid().ToString(), CardIdentifier = Guid.NewGuid().ToString() };
            var errors = validator.GetErrors(card);
            Assert.That(errors.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Card_WithInValidDetails_MissingMSK()
        {
            var card = new OpayoCard() { CardIdentifier = Guid.NewGuid().ToString() };
            var errors = validator.GetErrors(card);
            Assert.That(errors.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Card_WithInValidDetails_MissingCardIdentifier()
        {
            var card = new OpayoCard() { MerchantSessionKey = Guid.NewGuid().ToString() };
            var errors = validator.GetErrors(card);
            Assert.That(errors.Count(), Is.EqualTo(1));
        }
    }
}