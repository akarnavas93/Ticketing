namespace Shared.Abstractions;

public readonly struct Result<T>
{
    public Error Error { get; private init; }

    public bool IsSuccess { get; private init; }

    public T Value { get; private init; }

    private Result(Error error)
    {
        IsSuccess = false;
        Error = error;
        Value = default!;
    }

    private Result(T value)
    {
        if (typeof(T) != typeof(object) &&
          value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        IsSuccess = true;
        Error = Error.None;
        Value = value;
    }

    public static implicit operator Result<T>(Error error)
    {
        return new Result<T>(error);
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(value);
    }
}
