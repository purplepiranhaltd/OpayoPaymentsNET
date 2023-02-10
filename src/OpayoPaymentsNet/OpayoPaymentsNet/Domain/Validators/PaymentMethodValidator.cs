using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Validators
{
    public class PaymentMethodValidator : IValidator<OpayoPaymentMethod>
    {
        public IEnumerable<Error> GetErrors(OpayoPaymentMethod entity)
        {
            return (FindErrors(entity));
        }


        private IEnumerable<Error> FindErrors(OpayoPaymentMethod obj)
        {
            var errors = new List<Error>();
            if (obj.ApplePay is null && obj.Card is null)
                errors.Add(Errors.PaymentMethod.MustSpecifyCardOrApplePay);
            else
            {
                if (obj.ApplePay is not null && obj.Card is not null)
                    errors.Add(Errors.PaymentMethod.MustSpecifyEitherCardOrApplePayNotBoth);
                else
                {
                    if (obj.ApplePay is not null)
                        errors.AddRange(new ApplePayValidator().GetErrors(obj.ApplePay));

                    if (obj.Card is not null)
                        errors.AddRange(new CardValidator().GetErrors(obj.Card));
                }
            }

            return errors;
        }
    }
}
