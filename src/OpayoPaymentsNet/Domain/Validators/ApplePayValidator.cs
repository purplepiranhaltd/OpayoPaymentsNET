using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Validators
{
    public class ApplePayValidator : IValidator<OpayoApplePay>
    {
        public IEnumerable<Error> GetErrors(OpayoApplePay entity)
        {
            return (FindErrors(entity));
        }


        private IEnumerable<Error> FindErrors(OpayoApplePay obj)
        {
            // TODO: ApplePay validation
            // Can we assume that all fields are required?
            return new List<Error>();
        }
    }
}
