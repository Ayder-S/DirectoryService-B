using DS.Domain.Entities;

namespace DS.Domain.Relation;

public class DepartmentPosition
{
    private DepartmentPosition() { }

    private DepartmentPosition(Guid departmentId, Guid positionId)
    {
        DepartmentPositionId = Guid.CreateVersion7();
        DepartmentId = departmentId;
        PositionId = positionId;
        
    }
    
    public Guid DepartmentPositionId { get; private set; }
    
    public Guid DepartmentId { get; private set; }

    public Guid PositionId { get; private set; }

    public static DepartmentPosition Create(Guid departmentId, Guid positionId)
    {
        return new DepartmentPosition(departmentId, positionId);
    }
}