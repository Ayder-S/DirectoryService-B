using CSharpFunctionalExtensions;
using Shared.Constants;
using Shared.Failures;

namespace DS.Domain.ValueObjects;

public record Address
{
    private Address(string country, string region, string city, string? street, string? building)
    {
        Country = country;
        Region = region;
        City = city;
        Street = street;
        Building = building;
    }

    public string Country { get; }
    public string Region { get; }
    public string City { get; }
    public string? Street { get; }
    public string? Building { get; }

    public static Result<Address, Error> Create(
        string country, 
        string region, 
        string city, 
        string? street, 
        string? building)
    {
        if (string.IsNullOrWhiteSpace(country)
            || string.IsNullOrWhiteSpace(region) 
            || string.IsNullOrWhiteSpace(city))
            return Error.Failure("record.is.not.valid", "Страна, регион и город обязательны");

        if (country.Length > LengthConstants.Address.MAX_LENGTH)
            return Error.Failure("country.is.not.valid", "Слишком длинное название страны");

        if (city.Length > LengthConstants.Address.MAX_LENGTH)
            return Error.Failure("city.is.not.valid", "Слишком длинное название города");

        if (region.Length > LengthConstants.Address.MAX_LENGTH)
            return Error.Failure("region.is.not.valid", "Слишком длинное название региона или области");

        if (street?.Length > LengthConstants.Address.MAX_LENGTH)
            return Error.Failure(string.Empty, "Слишком длинная улица");

        if (building?.Length > LengthConstants.Address.MAX_LENGTH)
            return Error.Failure(string.Empty, "Слишком длинный номер здания");

        country = country.Trim();
        city = city.Trim();
        region = region.Trim();
        street = street?.Trim();
        building = building?.Trim();

        return new Address(country, region, city, street, building);
    }
}