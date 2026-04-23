using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Shared.Constants;

namespace DS.Domain.ValueObjects;

public record Identifier
{
    private const string PATTERN = "^[a-z]+(-[a-z]+)*$";
    private static readonly Regex _identifierFormat = new (PATTERN, RegexOptions.Compiled | RegexOptions.CultureInvariant);


    private Identifier(string value)
    {
        Value = value;
    }

    public string Value { get; }


    public static Result<Identifier> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Identifier>("Идентификатор должен быть заполнен");

        string normalized = value.Trim().ToLowerInvariant();

        if (normalized.Length < LengthConstants.Identifier.MIN_LENGTH || normalized.Length > LengthConstants.Identifier.MAX_LENGTH)
            return Result.Failure<Identifier>($"Идентификатор может быть длиной от {LengthConstants.Identifier.MIN_LENGTH} до {LengthConstants.Identifier.MAX_LENGTH} символов");

        if (!_identifierFormat.IsMatch(normalized))
            return Result.Failure<Identifier>("Идентификатор может состоять только из латиницы , а также дефиса только в середине идентификатора");

        return new Identifier(normalized);
    }
}