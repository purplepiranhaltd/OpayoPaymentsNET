using OpayoPaymentsNet.Domain.Builders.CardIdentifiers;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Tests.UnitTests
{
    public class OpayoCardIdentifierRequestBuilderUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateCardIdentifierRequest_WithValidCardDetails()
        {
            var builder = OpayoCardIdentifierRequestBuilder.Create();
            var request = builder
                .WithCardholderName("SUCCESSFUL")
                .WithCardNumber("4929000000006")
                .WithExpiryDate("1229")
                .WithSecurityCode("123")
                .Build();

            if (request.IsFailure)
                Assert.Fail();
        }

        [Test]
        public void CreateCardIdentifierRequest_WithInvalidCardDetails_MissingSecurityCode()
        {
            var builder = OpayoCardIdentifierRequestBuilder.Create();
            var request = builder
                .WithCardholderName("SUCCESSFUL")
                .WithCardNumber("4929000000006")
                .WithExpiryDate("1229")
                .Build();

            if (request.IsSuccess)
                Assert.Fail();
        }

        [Test]
        public void CreateCardIdentifierRequest_WithInvalidCardDetails_MissingExpiryDate()
        {
            var builder = OpayoCardIdentifierRequestBuilder.Create();
            var request = builder
                .WithCardholderName("SUCCESSFUL")
                .WithCardNumber("4929000000006")
                .WithSecurityCode("123")
                .Build();

            if (request.IsSuccess)
                Assert.Fail();
        }

        [Test]
        public void CreateCardIdentifierRequest_WithInvalidCardDetails_MissingCardholderName()
        {
            var builder = OpayoCardIdentifierRequestBuilder.Create();
            var request = builder
                .WithCardNumber("4929000000006")
                .WithExpiryDate("1229")
                .WithSecurityCode("123")
                .Build();

            if (request.IsSuccess)
                Assert.Fail();
        }

        [Test]
        public void CreateCardIdentifierRequest_WithInvalidCardDetails_MissingCardNumber()
        {
            var builder = OpayoCardIdentifierRequestBuilder.Create();
            var request = builder
                .WithCardholderName("SUCCESSFUL")
                .WithExpiryDate("1229")
                .WithSecurityCode("123")
                .Build();

            if (request.IsSuccess)
                Assert.Fail();
        }
    }
}