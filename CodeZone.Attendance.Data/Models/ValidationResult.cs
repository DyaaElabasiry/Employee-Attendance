namespace CodeZone.Attendance.Business.Models;

public class ValidationResult
{
    public bool IsValid { get; set; }
    public Dictionary<string, string> Errors { get; set; } = new();

    public static ValidationResult Success() => new() { IsValid = true };
    
    public void AddError(string key, string message)
    {
        IsValid = false;
        Errors[key] = message;
    }
}