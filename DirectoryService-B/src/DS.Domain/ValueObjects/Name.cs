using CSharpFunctionalExtensions;
using Shared.Constants;
using Shared.Failures;


namespace DS.Domain.ValueObjects;

public record Name
{ 
    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; }


    public static Result<Name, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) 
            || value.Length < LengthConstants.Name.MIN_LENGTH
            || value.Length > LengthConstants.Name.MAX_LENGTH)
            return Error.Failure("name.is.not.valid", $"Название должно быть длиной от {LengthConstants.Name.MIN_LENGTH} до {LengthConstants.Name.MAX_LENGTH} символов");

        string normalized = value.Trim();

        return new Name(normalized);
    }
    
    public static Name ReadName(string value) => new Name(value);
}