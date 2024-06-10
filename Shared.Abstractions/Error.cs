namespace Shared.Abstractions;

public record Error(string Code, string? Description = null, int StatusCode = 200)
{
    public static readonly Error None = new(string.Empty);

    public static Error NullValue(string valueName) => new($"{valueName}.NullValue", $"{valueName} value is null.", 400);

    public static Error NullOrEmptyValue(string valueName) => new($"{valueName}.NullOrEmptyValue", $"{valueName} value is empty or null.", 400);
}
