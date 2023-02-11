using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    ////public interface ITransactionBuilder : IOpayoCreateTransactionRequestBuilder
    ////{
    ////}

    public interface IOpayoCreateTransactionRequestWithVendorTxCodeBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoCreateTransactionRequestWithDescriptionBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoCreateTransactionRequestWithAmountBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoCreateTransactionRequestWithTransactionTypeBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : ITransactionType
    {
    }

    public interface IOpayoCreateTransactionRequestWithTransactionTypeBuilder :
        IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IPaymentTransaction>,
        IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IDeferredTransaction>,
        IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IAuthenticateTransaction>,
        IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction>,
        IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IAuthoriseTransaction>,
        IOpayoCreateTransactionRequestWithTransactionTypeBuilder<IRefundTransaction>
    {
    }

    public interface IOpayoCreateTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoCreateTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T> : IBuildableBuilderWithTransactionType<T>, IBuilder<OpayoCreateTransactionRequest> where T : IAuthoriseRefundTransaction
    {
    }

    public interface IOpayoCreateTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder :
        IOpayoCreateTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<IAuthoriseTransaction>,
        IOpayoCreateTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<IRefundTransaction>
    {
    }

    public interface IOpayoCreateTransactionRequestRepeatTransactionWithCurrencyBuilder : IBuildableBuilderWithTransactionType<IRepeatTransaction>, IBuilder<OpayoCreateTransactionRequest>
    { 
    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder :
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IPaymentTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IDeferredTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder :
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IPaymentTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IDeferredTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder :
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IPaymentTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IDeferredTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder :
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IPaymentTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IDeferredTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T> : IBuildableBuilderWithTransactionType<T>, IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder :
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IPaymentTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IDeferredTransaction>,
        IOpayoCreateTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IAuthenticateTransaction>
    {

    }

}
