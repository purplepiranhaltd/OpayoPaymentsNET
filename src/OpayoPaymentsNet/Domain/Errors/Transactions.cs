using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Errors
{
    public static class Transactions
    {
        public static readonly Error VendorTxCodeRequired = new Error(
            $"{nameof(Transactions)}.{nameof(VendorTxCodeRequired)}",
            "The vendor transaction code is required."
            );

        public static readonly Error DescriptionRequired = new Error(
            $"{nameof(Transactions)}.{nameof(DescriptionRequired)}",
            "The description is required."
            );

        public static readonly Error AmountRequired = new Error(
            $"{nameof(Transactions)}.{nameof(AmountRequired)}",
            "The amount is required."
            );

        public static readonly Error TransactionTypeRequired = new Error(
            $"{nameof(Transactions)}.{nameof(TransactionTypeRequired)}",
            "The transaction type is required."
            );

        public static readonly Error ReferenceTransactionIdRequired = new Error(
            $"{nameof(Transactions)}.{nameof(ReferenceTransactionIdRequired)}",
            "The reference transaction id is required for 'Repeat', 'Authorise' and 'Refund' transaction types."
            );

        public static readonly Error CurrencyRequired = new Error(
            $"{nameof(Transactions)}.{nameof(CurrencyRequired)}",
            "The currency is required for 'Payment', 'Deferred', 'Authenticate' and 'Repeat' transaction types."
            );

        public static readonly Error PaymentMethodRequired = new Error(
            $"{nameof(Transactions)}.{nameof(PaymentMethodRequired)}",
            "The payment method is required for 'Payment', 'Deferred', and 'Authenticate' transaction types."
            );

        public static readonly Error CustomerFirstNameRequired = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerFirstNameRequired)}",
            "The customer first name is required for 'Payment', 'Deferred', and 'Authenticate' transaction types."
            );

        public static readonly Error CustomerLastNameRequired = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerLastNameRequired)}",
            "The customer last name is required for 'Payment', 'Deferred', and 'Authenticate' transaction types."
            );

        public static readonly Error BillingAddressRequired = new Error(
            $"{nameof(Transactions)}.{nameof(BillingAddressRequired)}",
            "The billing address is required for 'Payment', 'Deferred', and 'Authenticate' transaction types."
            );

        public static readonly Error VendorTxCodeInvalid = new Error(
            $"{nameof(Transactions)}.{nameof(VendorTxCodeInvalid)}",
            "The vendor transaction code is invalid. Must be <= 40 characters."
            );

        public static readonly Error DescriptionInvalid = new Error(
            $"{nameof(Transactions)}.{nameof(DescriptionInvalid)}",
            "The description is invalid. Must be <= 100 characters."
            );

        public static readonly Error AmountInvalid = new Error(
            $"{nameof(Transactions)}.{nameof(AmountInvalid)}",
            "The amount is invalid. Amount is either zero or a negative value. Must be a positive value."
            );

        public static readonly Error CurrencyInvalid = new Error(
            $"{nameof(Transactions)}.{nameof(CurrencyInvalid)}",
            "The currency is invalid. Must be exactly 3 characters (ISO 4217 format)."
            );

        public static readonly Error CustomerFirstNameInvalid = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerFirstNameInvalid)}",
            "The customer first name is invalid. Must be <= 20 characters."
            );

        public static readonly Error CustomerLastNameInvalid = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerLastNameInvalid)}",
            "The customer first name is invalid. Must be <= 20 characters."
            );

        // Optional Fields
        public static readonly Error Cv2InvalidLength = new Error(
            $"{nameof(Transactions)}.{nameof(Cv2InvalidLength)}",
            "If specified, the Cv2 must be either 3 or 4 characters."
            );

        
        public static readonly Error Cv2NotAllowed = new Error(
            $"{nameof(Transactions)}.{nameof(Cv2NotAllowed)}",
            "The Cv2 can only be specified during Authorise transactions."
            );


        public static readonly Error SettlementReferenceTextInvalidLength = new Error(
            $"{nameof(Transactions)}.{nameof(SettlementReferenceTextInvalidLength)}",
            "The settlement reference text is invalid. Must be <= 30 characters."
            );

        public static readonly Error CustomerEmailInvalidLength = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerEmailInvalidLength)}",
            "The customer email is invalid. Must be <= 80 characters."
            );

        public static readonly Error CustomerPhoneInvalidLength = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerPhoneInvalidLength)}",
            "The customer phone is invalid. Must be <= 19 characters."
            );

        public static readonly Error CustomerMobilePhoneInvalidLength = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerMobilePhoneInvalidLength)}",
            "The customer mobile phone is invalid. Must be <= 19 characters."
            );

        public static readonly Error CustomerWorkPhoneInvalidLength = new Error(
            $"{nameof(Transactions)}.{nameof(CustomerWorkPhoneInvalidLength)}",
            "The customer work phone is invalid. Must be <= 19 characters."
            );

        public static readonly Error ReferrerIdInvalidLength = new Error(
            $"{nameof(Transactions)}.{nameof(ReferrerIdInvalidLength)}",
            "The referrer is invalid. Must be <= 40 characters."
            );
    }
}
