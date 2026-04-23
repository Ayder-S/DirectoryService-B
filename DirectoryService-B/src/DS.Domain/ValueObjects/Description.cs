using CSharpFunctionalExtensions;
using Shared.Constants;

namespace DS.Domain.ValueObjects;

public record Description
{
    private Description(string? description)
    {
        Value = description;
    }

    public string? Value { get; }


    public static Result<Description> Create(string? description)
    {
        if (description?.Length > LengthConstants.Description.MAX_LENGTH)
            return Result.Failure<Description>("Введено слишком длинное описание");

        return new Description(description?.Trim());
    }
}