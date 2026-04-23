using CSharpFunctionalExtensions;
using Shared.Constants;

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

    public static Result<Address> Create(
        string country, 
        string region, 
        string city, 
        string? street, 
        string? building)
    {
        if (string.IsNullOrWhiteSpace(country)
            || string.IsNullOrWhiteSpace(region) 
            || string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("Страна, регион и город обязательны");

        if (country.Length > LengthConstants.Address.MAX_LENGTH)
            return Result.Failure<Address>("Слишком длинное название страны");

        if (city.Length > LengthConstants.Address.MAX_LENGTH)
            return Result.Failure<Address>("Слишком длинное название города");

        if (region.Length > LengthConstants.Address.MAX_LENGTH)
            return Result.Failure<Address>("Слишком длинное название региона или области");

        if (street?.Length > LengthConstants.Address.MAX_LENGTH)
            return Result.Failure<Address>("Слишком длинная улица");

        if (building?.Length > LengthConstants.Address.MAX_LENGTH)
            return Result.Failure<Address>("Слишком длинный номер здания");

        country = country.Trim();
        city = city.Trim();
        region = region.Trim();
        street = street?.Trim();
        building = building?.Trim();

        return new Address(country, region, city, street, building);
    }
}