using OpayoPaymentsNet.Domain.Shared;

namespace OpayoPaymentsNet.Domain.Validators
{
    public interface IValidator<T>
    {
        IEnumerable<Error> GetErrors(T entity);
    }
}
