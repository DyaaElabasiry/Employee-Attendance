using CodeZone.Attendance.Data.Entities;

namespace CodeZone.Attendance.Web.ViewModels;

public class AttendanceListViewModel
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public AttendanceStatus Status { get; set; }
    public string StatusDisplay { get; set; } = string.Empty;
}