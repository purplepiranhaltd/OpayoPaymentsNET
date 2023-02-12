using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Validators
{
    public class CardValidator : IValidator<OpayoCard>
    {
        public IEnumerable<Error> GetErrors(OpayoCard entity)
        {
            return (FindErrors(entity));
        }


        private IEnumerable<Error> FindErrors(OpayoCard obj)
        {
            if (obj.MerchantSessionKey is null || obj.MerchantSessionKey.Length == 0)
                yield return Errors.PaymentMethod.Card.MerchantSessionKeyRequired;

            if (obj.CardIdentifier is null || obj.CardIdentifier.Length == 0)
                yield return Errors.PaymentMethod.Card.CardIdentifierRequired;
        }
    }
}
