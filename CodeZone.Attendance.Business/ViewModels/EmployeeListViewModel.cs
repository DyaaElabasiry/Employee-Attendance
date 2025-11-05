namespace CodeZone.Attendance.Web.ViewModels;

public class EmployeeListViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string DepartmentName { get; set; }
    public int Presents { get; set; }
    public int Absents { get; set; }
    public string AttendancePercentage { get; set; }
}
