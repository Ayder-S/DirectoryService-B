using CSharpFunctionalExtensions;
using DS.Domain.Entities;
using Shared.Failures;

namespace DS.Application.Database;

public interface ILocationsRepository
{
    Task<Result<Guid, Error>> Add(Location location, CancellationToken cancellationToken);
}