using CSharpFunctionalExtensions;

namespace DS.Domain.ValueObjects;

public record Path
{
    private const char SEPARATOR = '/';

    private Path(string value)
    {
        Value = value;
    }

    private Path(Path? parentPath, Identifier identifier)
    {
        if (parentPath == null)
            Value = identifier.Value;
        else
            Value = parentPath.Value + SEPARATOR + identifier.Value;
    }

    public char PathSeparator => SEPARATOR;
    public string Value { get; }

    public static Result<Path> CreateParent(Identifier identifier)
    {
        if (identifier is null)
            return Result.Failure<Path>("Идентификатор должен быть заполнен");

        return new Path(null, identifier);
    }

    public static Result<Path> CreateChild(Path? parentPath, Identifier identifier)
    {
        if (parentPath == null)
            return Result.Failure<Path>("Не введен родительский путь");
        
        if (identifier is null)
            return Result.Failure<Path>("Идентификатор должен быть заполнен");

        return new Path(parentPath, identifier);
    }

    public static Path ReadPath(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException($"Невалидное значение Path в БД: '{value}'");
    
        return new Path(value);
    }
}