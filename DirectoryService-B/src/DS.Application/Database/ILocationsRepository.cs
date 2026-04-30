using DS.Domain.Entities;

namespace DS.Application.Database;

public interface ILocationsRepository
{
    Task<Guid> Add(Location location, CancellationToken cancellationToken);
}