using DS.Domain.Entities;

namespace DS.Domain.Relation;

public class DepartmentLocation
{
    private DepartmentLocation() { }
    
    private DepartmentLocation(Guid departmentId, Guid locationId)
    {
        Id = Guid.NewGuid();
        DepartmentId = departmentId;
        LocationId = locationId;
    }
    
    public Guid Id { get; private set; }

    public Guid DepartmentId { get; private set; }
    
    public Guid LocationId { get; private set; }

    public Department Department { get; private set; } = null!;

    public Location Location { get; private set; } = null!;

    public static DepartmentLocation Create(Guid departmentId, Guid locationId)
    {
        return new DepartmentLocation(departmentId, locationId);
    }
}