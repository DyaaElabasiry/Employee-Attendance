using CodeZone.Attendance.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CodeZone.Attendance.Web.ViewModels;

public class AttendanceFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Employee is required")]
    [Display(Name = "Employee")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Date")]
    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Status is required")]
    [Display(Name = "Status")]
    public AttendanceStatus Status { get; set; }
}