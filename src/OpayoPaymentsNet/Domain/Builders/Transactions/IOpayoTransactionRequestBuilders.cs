
/* Unmerged change from project 'OpayoPaymentsNet (net6.0)'
Before:
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
After:
using OpayoPaymentsNet;
using OpayoPaymentsNet.Domain;
using OpayoPaymentsNet.Domain.Builders;
using OpayoPaymentsNet.Domain.Builders.Transactions;
using OpayoPaymentsNet.Domain.Builders.Transactions;
using OpayoPaymentsNet.Domain.Builders.Transactions.CreateTransactionRequest;
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
*/
using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    ////public interface ITransactionBuilder : IOpayoTransactionRequestBuilder
    ////{
    ////}

    public interface IOpayoTransactionRequestWithVendorTxCodeBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoTransactionRequestWithDescriptionBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoTransactionRequestWithAmountBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoTransactionRequestWithTransactionTypeBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IOpayoTransactionType
    {
    }

    public interface IOpayoTransactionRequestWithTransactionTypeBuilder :
        IOpayoTransactionRequestWithTransactionTypeBuilder<IPaymentTransaction>,
        IOpayoTransactionRequestWithTransactionTypeBuilder<IDeferredTransaction>,
        IOpayoTransactionRequestWithTransactionTypeBuilder<IAuthenticateTransaction>,
        IOpayoTransactionRequestWithTransactionTypeBuilder<IRepeatTransaction>,
        IOpayoTransactionRequestWithTransactionTypeBuilder<IAuthoriseTransaction>,
        IOpayoTransactionRequestWithTransactionTypeBuilder<IRefundTransaction>
    {
    }

    public interface IOpayoTransactionRequestRepeatTransactionWithReferenceTransactionIdBuilder : IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<T> : IBuildableBuilderWithOpayoTransactionType<T>, IBuilder<OpayoCreateTransactionRequest> where T : IAuthoriseRefundTransaction
    {
    }

    public interface IOpayoTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder :
        IOpayoTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<IAuthoriseTransaction>,
        IOpayoTransactionRequestAuthoriseRefundTransactionWithReferenceTransactionIdBuilder<IRefundTransaction>
    {
    }

    public interface IOpayoTransactionRequestRepeatTransactionWithCurrencyBuilder : IBuildableBuilderWithOpayoTransactionType<IRepeatTransaction>, IBuilder<OpayoCreateTransactionRequest>
    {
    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder :
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IPaymentTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IDeferredTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCurrencyBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder :
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IPaymentTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IDeferredTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithPaymentMethodBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder :
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IPaymentTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IDeferredTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerFirstNameBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<T> : IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder :
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IPaymentTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IDeferredTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithCustomerLastNameBuilder<IAuthenticateTransaction>
    {

    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<T> : IBuildableBuilderWithOpayoTransactionType<T>, IBuilder<OpayoCreateTransactionRequest> where T : IPaymentDeferredAuthenticateTransaction
    {
    }

    public interface IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder :
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IPaymentTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IDeferredTransaction>,
        IOpayoTransactionRequestPaymentDeferredAuthenticateTransactionWithBillingAddressBuilder<IAuthenticateTransaction>
    {

    }

}
