namespace CodeZone.Attendance.Data.Entities;

public class Employee
{
    public int Id { get; set; }
    
    
    public string FullName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    // Foreign Key
    public int DepartmentId { get; set; }
    
    // Navigation properties
    public Department Department { get; set; } = null!;
    
    public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
}