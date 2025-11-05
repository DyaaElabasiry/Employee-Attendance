using CodeZone.Attendance.Business.Interfaces;
using CodeZone.Attendance.Business.Models;
using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Data.Repositories.Interfaces;
using CodeZone.Attendance.Web.ViewModels;

namespace CodeZone.Attendance.Business;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepo;

    public DepartmentService(IDepartmentRepository departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    public async Task<List<DepartmentListViewModel>> GetAllDepartmentsAsync()
    {
        // Get all entities from repository
        var departments = await _departmentRepo.GetAllAsync();

        // Map entities to view models
        return departments.Select(dept => new DepartmentListViewModel
        {
            Id = dept.Id,
            Name = dept.Name,
            Code = dept.Code,
            Location = dept.Location,
            EmployeeCount = dept.Employees?.Count ?? 0
        }).ToList();
    }

    public async Task<PagedResult<DepartmentListViewModel>> GetPagedDepartmentListAsync(int page, int pageSize)
    {
        // Get paginated entities from repository
        var pagedDepartmentEntities = await _departmentRepo.GetPagedDepartments(page, pageSize);

        // Map entities to view models
        var departmentViewModels = pagedDepartmentEntities.Items.Select(dept => new DepartmentListViewModel
        {
            Id = dept.Id,
            Name = dept.Name,
            Code = dept.Code,
            Location = dept.Location,
            EmployeeCount = dept.Employees?.Count ?? 0
        }).ToList();

        // Create paged result for view models
        return new PagedResult<DepartmentListViewModel>
        {
            Items = departmentViewModels,
            Page = pagedDepartmentEntities.Page,
            PageSize = pagedDepartmentEntities.PageSize,
            TotalCount = pagedDepartmentEntities.TotalCount
        };
    }

    public async Task<DepartmentFormViewModel?> GetDepartmentForEditAsync(int id)
    {
        var department = await _departmentRepo.GetByIdAsync(id);
        
        if (department == null)
            return null;

        return new DepartmentFormViewModel
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Location = department.Location
        };
    }

    public Task<DepartmentFormViewModel> GetDepartmentFormViewModelAsync()
    {
        // Return empty form model for create
        return Task.FromResult(new DepartmentFormViewModel());
    }

    public async Task<bool> CreateDepartmentAsync(DepartmentFormViewModel model)
    {
        // Business Logic: Check if code and name are unique
        var isCodeUnique = await IsCodeUniqueAsync(model.Code);
        var isNameUnique = await IsNameUniqueAsync(model.Name);

        if (!isCodeUnique || !isNameUnique)
            return false;

        var department = new Department
        {
            Name = model.Name,
            Code = model.Code,
            Location = model.Location
        };

        await _departmentRepo.AddAsync(department);
        return true;
    }

    public async Task<bool> UpdateDepartmentAsync(DepartmentFormViewModel model)
    {
        // Business Logic: Check if department exists
        var department = await _departmentRepo.GetByIdAsync(model.Id);
        
        if (department == null)
            return false;

        // Business Logic: Check if code and name are unique (excluding current department)
        var isCodeUnique = await IsCodeUniqueAsync(model.Code, model.Id);
        var isNameUnique = await IsNameUniqueAsync(model.Name, model.Id);

        if (!isCodeUnique || !isNameUnique)
            return false;

        // Business Logic: Update entity properties
        department.Name = model.Name;
        department.Code = model.Code;
        department.Location = model.Location;

        // Repository: Only performs the update operation
        await _departmentRepo.UpdateAsync(department);
        return true;
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        // Business Logic: Check if department exists
        var department = await _departmentRepo.GetByIdAsync(id);
        
        if (department == null)
            return false;

        // Business Logic: Check if department has employees (business rule)
        var employeeCount = await _departmentRepo.GetEmployeeCountAsync(id);
        
        if (employeeCount > 0)
            return false; // Cannot delete department with employees

        // Repository: Only performs the delete operation
        return await _departmentRepo.DeleteAsync(id);
    }
    public async Task<ValidationResult> ValidateDepartmentAsync(DepartmentFormViewModel model)
    {
        var result = ValidationResult.Success();

        // Check code uniqueness
        var isCodeUnique = await IsCodeUniqueAsync(model.Code, model.Id);
        if (!isCodeUnique)
        {
            result.AddError("Code", "This department code is already in use.");
        }

        // Check name uniqueness
        var isNameUnique = await IsNameUniqueAsync(model.Name, model.Id);
        if (!isNameUnique)
        {
            result.AddError("Name", "This department name is already in use.");
        }

        return result;
    }
    public async Task<bool> IsCodeUniqueAsync(string code, int departmentId = 0)
    {
        return await _departmentRepo.IsCodeUniqueAsync(departmentId, code);
    }

    public async Task<bool> IsNameUniqueAsync(string name, int departmentId = 0)
    {
        return await _departmentRepo.IsNameUniqueAsync(departmentId, name);
    }
}
