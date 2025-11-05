using System.ComponentModel.DataAnnotations;

namespace CodeZone.Attendance.Web.ViewModels;

public class DepartmentFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Department name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Department name must be between 3 and 50 characters.")]
    [Display(Name = "Department Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department code is required.")]
    [StringLength(4, MinimumLength = 4, ErrorMessage = "Department code must be exactly 4 characters.")]
    [RegularExpression(@"^[A-Z]{4}$", ErrorMessage = "Department code must be exactly 4 uppercase alphabetic characters (e.g., HRMG, TECH).")]
    [Display(Name = "Department Code")]
    public string Code { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
    [Display(Name = "Location")]
    public string Location { get; set; } = string.Empty;
}