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
    }
}