using CSharpFunctionalExtensions;
using DS.Application.Database;
using DS.Contracts;
using DS.Domain.Entities;
using DS.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace DS.Application.Locations;

public class CreateLocationHandler
{
    private readonly ILocationsRepository _locationsRepository;
    private readonly ILogger<CreateLocationHandler> _logger;
    
    public CreateLocationHandler(
        ILocationsRepository locationsRepository,
        ILogger<CreateLocationHandler> logger)
    {
        _locationsRepository = locationsRepository;
        _logger = logger;
    }

    public async Task<Result<Guid>> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var nameResult = Name.Create(request.Name);
        if (!nameResult.IsSuccess)
            return Result.Failure<Guid>(nameResult.Error);
        
        var addressResult = Address.Create(
            request.Address.Country,
            request.Address.Region,
            request.Address.City,
            request.Address.Street,
            request.Address.Building);
        if (!addressResult.IsSuccess)
            return Result.Failure<Guid>(addressResult.Error);
        
        var timezoneResult = Timezone.Create(request.Timezone);
        if(!timezoneResult.IsSuccess)
            return Result.Failure<Guid>(timezoneResult.Error);
        
        var location = Location.Create(nameResult.Value, addressResult.Value, timezoneResult.Value);

        await _locationsRepository.Add(location.Value, cancellationToken);
        
        return location.Value.Id;
    }
}