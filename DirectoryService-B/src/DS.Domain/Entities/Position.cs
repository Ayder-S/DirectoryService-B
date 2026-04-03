using CSharpFunctionalExtensions;
using DS.Domain.Relation;
using DS.Domain.ValueObjects;

namespace DS.Domain.Entities;

public class Position
{
    private readonly List<DepartmentPosition> _departments = [];
    
    private Position() { }
  
    public Position(Name name, Description description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = true; 
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public IReadOnlyList<DepartmentPosition> Departments => _departments;

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Result<Position> Create(Name name, Description description)
    {
        if (name is null)
            return Result.Failure<Position>("Должность не может быть пустой");

        if (description is null)
            return Result.Failure<Position>("Описание должности не может быть пустым");
        
        return new Position(name, description);
    }
}