namespace CodeZone.Attendance.Data.Entities;

public class Department
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Code { get; set; } = string.Empty;
    
    public string Location { get; set; } = string.Empty;
    
    // Navigation property
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}