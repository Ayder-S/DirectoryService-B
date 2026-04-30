using DS.Application.Database;
using DS.Domain.Entities;

namespace DS.Infrastructure.Postgresql.Repositories;

public class EfCoreLocationsRepository : ILocationsRepository
{
    private readonly DirectoryServiceDbContext _dbContext;
    
    public EfCoreLocationsRepository(DirectoryServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(
        Location location,
        CancellationToken cancellationToken)
    {
        await _dbContext.Locations.AddAsync(location, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return location.Id;
    }
}