using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions.Interfaces
{
    public interface ITransactionBuilder : IOpayoCreateTransactionRequestBuilder
    {
    }

    public interface ITransactionWithVendorTxCodeBuilder : IOpayoCreateTransactionRequestBuilder
    {
    }

    public interface ITransactionWithDescriptionBuilder : IOpayoCreateTransactionRequestBuilder
    {
    }

    public interface ITransactionWithAmountBuilder : IOpayoCreateTransactionRequestBuilder
    {
    }

    public interface ITransactionWithTransactionTypeBuilder<T> : IOpayoCreateTransactionRequestBuilder where T : ITransactionType
    {
    }

    public interface ITransactionWithTransactionTypeBuilder :
        ITransactionWithTransactionTypeBuilder<IPaymentTransaction>,
        ITransactionWithTransactionTypeBuilder<IDeferredTransaction>,
        ITransactionWithTransactionTypeBuilder<IAuthenticateTransaction>,
        ITransactionWithTransactionTypeBuilder<IRepeatTransaction>,
        ITransactionWithTransactionTypeBuilder<IAuthoriseTransaction>,
        ITransactionWithTransactionTypeBuilder<IRefundTransaction>
    {
    }

    public interface IRepeatTransactionTransactionWithReferenceTransactionIdBuilder : IOpayoCreateTransactionRequestBuilder
    {
    }

    public interface IAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T> : IBuildableTransactionBuilder<T>,  IOpayoCreateTransactionRequestBuilder where T : IAuthoriseRefundTransaction
    {
    }

    public interface IAuthoriseRefundTransactionWithReferenceTransactionIdBuilder :
        IAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<IAuthoriseTransaction>,
        IAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<IRefundTransaction>
    {
    }

    public interface IRepeatTransactionWithCurrencyBuilder : IBuildableTransactionBuilder<IRepeatTransaction>, IOpayoCreateTransactionRequestBuilder
    { 
    }

    public interface IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> : IOpayoCreateTransactionRequestBuilder where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder :
        IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IPaymentTransaction>,
        IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IDeferredTransaction>,
        IPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IAuthenticateTransaction>
    {

    }

    public interface IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> : IOpayoCreateTransactionRequestBuilder where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder :
        IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IPaymentTransaction>,
        IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IDeferredTransaction>,
        IPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IAuthenticateTransaction>
    {

    }

    public interface IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> : IOpayoCreateTransactionRequestBuilder where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder :
        IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IPaymentTransaction>,
        IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IDeferredTransaction>,
        IPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IAuthenticateTransaction>
    {

    }

    public interface IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> : IOpayoCreateTransactionRequestBuilder where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder :
        IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IPaymentTransaction>,
        IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IDeferredTransaction>,
        IPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IAuthenticateTransaction>
    {

    }

    public interface IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T> : IBuildableTransactionBuilder, IOpayoCreateTransactionRequestBuilder where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder :
        IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IPaymentTransaction>,
        IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IDeferredTransaction>,
        IPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IAuthenticateTransaction>
    {

    }

}
