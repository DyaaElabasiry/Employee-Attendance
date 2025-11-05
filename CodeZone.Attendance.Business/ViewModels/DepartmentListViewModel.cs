namespace CodeZone.Attendance.Web.ViewModels;

public class DepartmentListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int EmployeeCount { get; set; }
}