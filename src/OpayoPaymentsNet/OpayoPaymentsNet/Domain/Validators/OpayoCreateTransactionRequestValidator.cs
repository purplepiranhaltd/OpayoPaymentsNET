using OpayoPaymentsNet.Domain.Entities.CardIdentifiers;
using OpayoPaymentsNet.Domain.Entities.Shared;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Validators
{
    public class OpayoCreateTransactionRequestValidator : IValidator<OpayoCreateTransactionRequest>
    {
        public IEnumerable<Error> GetErrors(OpayoCreateTransactionRequest entity)
        {
            return (FindErrors(entity));
        }


        private IEnumerable<Error> FindErrors(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();

            // mandatory fields for all transaction types
            if (obj.VendorTxCode is null || obj.VendorTxCode.Length == 0)
                errors.Add(Errors.Transactions.VendorTxCodeRequired);
            else if (obj.VendorTxCode.Length > 40)
                errors.Add(Errors.Transactions.VendorTxCodeInvalid);

            if (obj.Description is null || obj.Description.Length == 0)
                errors.Add(Errors.Transactions.DescriptionRequired);
            else if (obj.Description.Length > 100)
                errors.Add(Errors.Transactions.DescriptionInvalid);

            if (obj.Amount is null)
                errors.Add(Errors.Transactions.AmountRequired);
            else if (obj.Amount.Value < 1)
                errors.Add(Errors.Transactions.AmountInvalid);

            if (obj.TransactionType is null)
                errors.Add(Errors.Transactions.TransactionTypeRequired);
            else
            {
                if (obj.TransactionType is Entities.Enums.TransactionType.Payment)
                    errors.AddRange(FindErrorsForTransactionTypePayment(obj));
                    
                if (obj.TransactionType is Entities.Enums.TransactionType.Deferred)
                    errors.AddRange(FindErrorsForTransactionTypeDeferred(obj));

                if (obj.TransactionType is Entities.Enums.TransactionType.Authenticate)
                    errors.AddRange(FindErrorsForTransactionTypeAuthenticate(obj));

                if (obj.TransactionType is Entities.Enums.TransactionType.Repeat)
                    errors.AddRange(FindErrorsForTransactionTypeRepeat(obj));

                if (obj.TransactionType is Entities.Enums.TransactionType.Authorise)
                    errors.AddRange(FindErrorsForTransactionTypeAuthorise(obj));

                if (obj.TransactionType is Entities.Enums.TransactionType.Refund)
                    errors.AddRange(FindErrorsForTransactionTypeRefund(obj));
            }

            return errors;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypePayment(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();
            errors.AddRange(FindErrorsForTransactionTypesPaymentDeferredAuthenticateRepeat(obj));
            errors.AddRange(FindErrorsForTransactionTypesPaymentDeferredAuthenticate(obj));
            errors.AddRange(FindErrorsInCvc(obj.Cv2, false));
            return errors;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypeDeferred(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();
            errors.AddRange(FindErrorsForTransactionTypesPaymentDeferredAuthenticateRepeat(obj));
            errors.AddRange(FindErrorsForTransactionTypesPaymentDeferredAuthenticate(obj));
            errors.AddRange(FindErrorsInCvc(obj.Cv2, false));
            return errors;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypeAuthenticate(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();
            errors.AddRange(FindErrorsForTransactionTypesPaymentDeferredAuthenticateRepeat(obj));
            errors.AddRange(FindErrorsForTransactionTypesPaymentDeferredAuthenticate(obj));
            errors.AddRange(FindErrorsInCvc(obj.Cv2, false));
            return errors;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypeRepeat(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();
            errors.AddRange(FindErrorsForTransactionTypesRepeatAuthoriseRefund(obj));
            errors.AddRange(FindErrorsForTransactionTypesPaymentDeferredAuthenticateRepeat(obj));
            errors.AddRange(FindErrorsInCvc(obj.Cv2, false));
            return errors;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypeAuthorise(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();
            errors.AddRange(FindErrorsForTransactionTypesRepeatAuthoriseRefund(obj));
            errors.AddRange(FindErrorsInCvc(obj.Cv2, true));
            return errors;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypeRefund(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();
            errors.AddRange(FindErrorsForTransactionTypesRepeatAuthoriseRefund(obj));
            errors.AddRange(FindErrorsInCvc(obj.Cv2, false));
            return errors;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypesRepeatAuthoriseRefund(OpayoCreateTransactionRequest obj)
        {
            // required
            if (obj.ReferenceTransactionId is null || obj.ReferenceTransactionId.Length == 0)
                yield return Errors.Transactions.ReferenceTransactionIdRequired;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypesPaymentDeferredAuthenticateRepeat(OpayoCreateTransactionRequest obj)
        {
            // required
            if (obj.Currency is null || obj.Currency.Length == 0)
                yield return Errors.Transactions.CurrencyRequired;
            else if (obj.Currency.Length is not 3)
                yield return Errors.Transactions.CurrencyInvalid;
        }

        private IEnumerable<Error> FindErrorsForTransactionTypesPaymentDeferredAuthenticate(OpayoCreateTransactionRequest obj)
        {
            var errors = new List<Error>();
            
            // required
            if (obj.PaymentMethod is null)
                errors.Add(Errors.Transactions.CurrencyRequired);
            else
                errors.AddRange(FindErrorsInPaymentMethod(obj.PaymentMethod));

            if (obj.CustomerFirstName is null || obj.CustomerFirstName.Length == 0)
                errors.Add(Errors.Transactions.CustomerFirstNameRequired);
            else if (obj.CustomerFirstName.Length > 20)
                errors.Add(Errors.Transactions.CustomerFirstNameInvalid);

            if (obj.CustomerLastName is null || obj.CustomerLastName.Length == 0)
                errors.Add(Errors.Transactions.CustomerLastNameRequired);
            else if (obj.CustomerLastName.Length > 20)
                errors.Add(Errors.Transactions.CustomerLastNameInvalid);

            if (obj.BillingAddress is null)
                errors.Add(Errors.Transactions.BillingAddressRequired);
            else
                errors.AddRange(FindErrorsInBillingAddress(obj.BillingAddress));

            // optional
            if (obj.SettlementReferenceText is not null && obj.SettlementReferenceText.Length > 30)
                errors.Add(Errors.Transactions.SettlementReferenceTextInvalidLength);

            if (obj.CustomerEmail is not null && obj.CustomerEmail.Length > 80)
                errors.Add(Errors.Transactions.CustomerEmailInvalidLength);

            if (obj.CustomerPhone is not null && obj.CustomerPhone.Length > 19)
                errors.Add(Errors.Transactions.CustomerPhoneInvalidLength);

            if (obj.CustomerMobilePhone is not null && obj.CustomerMobilePhone.Length > 19)
                errors.Add(Errors.Transactions.CustomerMobilePhoneInvalidLength);

            if (obj.CustomerWorkPhone is not null && obj.CustomerWorkPhone.Length > 19)
                errors.Add(Errors.Transactions.CustomerWorkPhoneInvalidLength);

            if (obj.ReferrerId is not null && obj.ReferrerId.Length > 40)
                errors.Add(Errors.Transactions.ReferrerIdInvalidLength);

            return errors;
        }

        private IEnumerable<Error> FindErrorsInPaymentMethod(OpayoPaymentMethod paymentMethod)
        {
            return new PaymentMethodValidator().GetErrors(paymentMethod);
        }

        private IEnumerable<Error> FindErrorsInBillingAddress(OpayoBillingAddress billingAddress)
        {
            return new BillingAddressValidator().GetErrors(billingAddress);
        }

        private IEnumerable<Error> FindErrorsInCvc(string? cv2, bool allowedForTransactionType)
        {
            var errors = new List<Error>();

            if (cv2 is null)
                return errors;

            if (allowedForTransactionType)
            {
                if (cv2.Length is not 3 or 4)
                {
                    errors.Add(Errors.Transactions.Cv2InvalidLength);
                }
            }
            else
            {
                errors.Add(Errors.Transactions.Cv2NotAllowed);
            }

            return errors;
        }
    }
}
