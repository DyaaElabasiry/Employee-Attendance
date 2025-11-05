using CodeZone.Attendance.Business.Interfaces;
using CodeZone.Attendance.Business.Models;
using CodeZone.Attendance.Data;
using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Data.Repositories.Interfaces;
using CodeZone.Attendance.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CodeZone.Attendance.Business;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepo;
    private readonly AttendanceDbContext _context;

    public EmployeeService(IEmployeeRepository employeeRepo, AttendanceDbContext context)
    {
        _employeeRepo = employeeRepo;
        _context = context;
    }

    public async Task<PagedResult<EmployeeListViewModel>> GetPagedEmployeeListAsync(int page, int pageSize)
    {
        // 1. Get paginated ENTITIES from the repository
        var pagedEmployeeEntities = await _employeeRepo.GetPagedEmployees(page, pageSize);

        // 2. Apply business logic and map Entities to ViewModels
        var employeeViewModels = pagedEmployeeEntities.Items.Select(emp => new EmployeeListViewModel
        {
            Id = emp.Id,
            FullName = emp.FullName,
            Email = emp.Email,
            DepartmentName = emp.Department.Name, // This works because of the .Include()

            // Call private helper methods *in the service* for all logic
            Presents = GetPresentCountForCurrentMonth(emp.AttendanceRecords),
            Absents = GetAbsentCountForCurrentMonth(emp.AttendanceRecords),
            AttendancePercentage = GetAttendancePercentage(
                                       GetPresentCountForCurrentMonth(emp.AttendanceRecords),
                                       GetAbsentCountForCurrentMonth(emp.AttendanceRecords))
        }).ToList();

        // 3. Create a new PagedResult for the VIEWMODELS
        return new PagedResult<EmployeeListViewModel>
        {
            Items = employeeViewModels,
            Page = pagedEmployeeEntities.Page,
            PageSize = pagedEmployeeEntities.PageSize,
            TotalCount = pagedEmployeeEntities.TotalCount
        };
    }
    public async Task<ValidationResult> ValidateEmployeeAsync(EmployeeFormViewModel model)
    {
        var result = ValidationResult.Success();

        // Check email uniqueness
        var isEmailUnique = await IsEmailUniqueAsync(model.Email, model.Id);
        if (!isEmailUnique)
        {
            result.AddError("Email", "This email address is already in use.");
        }

        return result;
    }
    public async Task<EmployeeFormViewModel?> GetEmployeeByIdAsync(int id)
    {
        var employee = await _employeeRepo.GetByIdAsync(id);
        
        if (employee == null)
            return null;

        

        return new EmployeeFormViewModel
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Email = employee.Email,
            DepartmentId = employee.DepartmentId,
            
        };
    }

    public async Task<EmployeeFormViewModel> GetEmployeeFormViewModelAsync()
    {
        

        return new EmployeeFormViewModel();
    }

    public async Task<bool> CreateEmployeeAsync(EmployeeFormViewModel model)
    {
        // Check if email is unique
        var isUnique = await IsEmailUniqueAsync(model.Email, 0);
        if (!isUnique)
            return false;

        var employee = new Employee
        {
            FullName = model.FullName,
            Email = model.Email,
            DepartmentId = model.DepartmentId
        };

        await _employeeRepo.AddAsync(employee);
        return true;
    }

    public async Task<bool> UpdateEmployeeAsync(EmployeeFormViewModel model)
    {
        var employee = await _employeeRepo.GetByIdAsync(model.Id);
        
        if (employee == null)
            return false;

        // Check if email is unique (excluding current employee)
        var isUnique = await IsEmailUniqueAsync(model.Email, model.Id);
        if (!isUnique)
            return false;

        employee.FullName = model.FullName;
        employee.Email = model.Email;
        employee.DepartmentId = model.DepartmentId;

        await _employeeRepo.UpdateAsync(employee);
        return true;
    }
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _employeeRepo.GetByIdAsync(id);
        await _employeeRepo.DeleteAsync(employee);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, int employeeId = 0)
    {
        return !await _context.Employees
            .AnyAsync(e => e.Email == email && e.Id != employeeId);
    }

    public async Task<List<EmployeeListViewModel>> GetAllEmployeesAsync()
    {
        var employees = await _employeeRepo.GetAllAsync();
        
        return employees.Select(emp => new EmployeeListViewModel
        {
            Id = emp.Id,
            FullName = emp.FullName,
            Email = emp.Email,
            DepartmentName = emp.Department.Name,
            Presents = GetPresentCountForCurrentMonth(emp.AttendanceRecords),
            Absents = GetAbsentCountForCurrentMonth(emp.AttendanceRecords),
            AttendancePercentage = GetAttendancePercentage(
                GetPresentCountForCurrentMonth(emp.AttendanceRecords),
                GetAbsentCountForCurrentMonth(emp.AttendanceRecords))
        }).ToList();
    }

    // --- HELPER METHODS ---

    

    private int GetPresentCountForCurrentMonth(ICollection<AttendanceRecord> records)
    {
        var today = DateTime.Today;
        // Assuming 'Status' is an enum: AttendanceStatus.Present
        return records.Count(r => r.Date.Month == today.Month &&
                                  r.Date.Year == today.Year &&
                                  r.Status == AttendanceStatus.Present);
    }

    private int GetAbsentCountForCurrentMonth(ICollection<AttendanceRecord> records)
    {
        var today = DateTime.Today;
        // Assuming 'Status' is an enum: AttendanceStatus.Absent
        return records.Count(r => r.Date.Month == today.Month &&
                                  r.Date.Year == today.Year &&
                                  r.Status == AttendanceStatus.Absent);
    }

    private string GetAttendancePercentage(int presents, int absents)
    {
        var total = presents + absents;
        if (total == 0)
            return "0%";

        var percentage = (double)presents / total * 100;
        return $"{percentage:F1}%";
    }
}