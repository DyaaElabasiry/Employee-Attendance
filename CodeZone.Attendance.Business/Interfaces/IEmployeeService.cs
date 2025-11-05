using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Web.ViewModels;

namespace CodeZone.Attendance.Business.Interfaces;

public interface IEmployeeService
{
    Task<PagedResult<EmployeeListViewModel>> GetPagedEmployeeListAsync(int page, int pageSize);
    Task<EmployeeFormViewModel?> GetEmployeeByIdAsync(int id);
    Task<EmployeeFormViewModel> GetEmployeeFormViewModelAsync();
    Task<bool> CreateEmployeeAsync(EmployeeFormViewModel model);
    Task<bool> UpdateEmployeeAsync(EmployeeFormViewModel model);
    Task DeleteEmployeeAsync(int id);
    Task<bool> IsEmailUniqueAsync(string email, int employeeId = 0);
}
