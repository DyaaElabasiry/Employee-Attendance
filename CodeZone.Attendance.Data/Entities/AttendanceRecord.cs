namespace CodeZone.Attendance.Data.Entities;

public class AttendanceRecord
{
    public int Id { get; set; }
    
    // Foreign Key
    public int EmployeeId { get; set; }
    
    public DateTime Date { get; set; }
    
    public AttendanceStatus Status { get; set; }
    
    // Navigation property
    public Employee Employee { get; set; } = null!;
}

public enum AttendanceStatus
{
    Present = 1,
    Absent = 2
}