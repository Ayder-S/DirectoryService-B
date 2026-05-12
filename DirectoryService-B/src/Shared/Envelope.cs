using Shared.Failures;

namespace Shared;

public record Envelope
{
    public object? Result { get; }
    public ErrorsList? Errors { get; }
    public DateTime GeneratedAt { get; }
    
    private  Envelope(object? result,  ErrorsList? errors)
    {
        Result = result;
        Errors = errors;
        GeneratedAt = DateTime.UtcNow;
    }
    
    public static Envelope Ok(object? result = null) => new(result, null);
    public static Envelope Fail(ErrorsList errors) => new(null, errors);
}