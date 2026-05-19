using DS.Domain.Entities;

namespace DS.Domain.Relation;

public class DepartmentLocation
{
    private DepartmentLocation() { }
    
    private DepartmentLocation(Guid departmentId, Guid locationId)
    {
        DepartmentLocationId = Guid.CreateVersion7();
        DepartmentId = departmentId;
        LocationId = locationId;
    }
    
    public Guid DepartmentLocationId { get; private set; }

    public Guid DepartmentId { get; private set; }
    
    public Guid LocationId { get; private set; }

    public static DepartmentLocation Create(Guid departmentId, Guid locationId)
    {
        return new DepartmentLocation(departmentId, locationId);
    }
}