using CSharpFunctionalExtensions;
using Shared.Failures;
using TimeZoneConverter;

namespace DS.Domain.ValueObjects;

public sealed record Timezone
{
    public string Value { get; }

    private Timezone(string value)
    {
        Value = value;
    }

    public static Result<Timezone, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Error.Failure("timezone.is.not.valid", "Часовой пояс не может быть пустым ");

        string normalized = value.Trim();

        if (!IsValid(normalized))
            return Error.Failure("timezone.is.not.valid", "Невалидный IANA код - пример верного формата : Europe/Moscow");

        return new Timezone(normalized);
    }

    private static bool IsValid(string value)
    {
        try
        {
            TZConvert.GetTimeZoneInfo(value);
            return true;
        }
        catch (TimeZoneNotFoundException)
        {
            return false;
        }
        catch (InvalidTimeZoneException)
        {
            return false;
        }
    }
    
    public static Timezone ReadTimezone(string value) => new Timezone(value);
}