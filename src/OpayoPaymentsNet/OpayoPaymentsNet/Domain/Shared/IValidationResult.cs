namespace OpayoPaymentsNet.Domain.Shared;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem occurred.");

    Error[] Errors { get; }
}

public interface IValidationResult<T> : IValidationResult
{
}
