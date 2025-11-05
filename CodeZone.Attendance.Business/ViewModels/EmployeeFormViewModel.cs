using System.ComponentModel.DataAnnotations;

namespace CodeZone.Attendance.Web.ViewModels;

public class EmployeeFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(200, ErrorMessage = "Full Name cannot exceed 200 characters")]
    [RegularExpression(@"^([A-Za-z]{2,}\s){3}[A-Za-z]{2,}$", ErrorMessage = "Full Name must consist of four names, each at least two characters long, containing only letters and spaces.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    [Display(Name = "Department")]
    public int DepartmentId { get; set; }

    // For populating the dropdown
    public List<DepartmentSelectItem>? Departments { get; set; }
}

public class DepartmentSelectItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}