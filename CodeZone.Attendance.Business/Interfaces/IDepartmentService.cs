using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Web.ViewModels;

namespace CodeZone.Attendance.Business.Interfaces;

public interface IDepartmentService
{
    Task<List<DepartmentListViewModel>> GetAllDepartmentsAsync();
    Task<PagedResult<DepartmentListViewModel>> GetPagedDepartmentListAsync(int page, int pageSize);
    Task<DepartmentFormViewModel?> GetDepartmentForEditAsync(int id);
    Task<DepartmentFormViewModel> GetDepartmentFormViewModelAsync();
    Task<bool> CreateDepartmentAsync(DepartmentFormViewModel model);
    Task<bool> UpdateDepartmentAsync(DepartmentFormViewModel model);
    Task<bool> DeleteDepartmentAsync(int id);
    Task<bool> IsCodeUniqueAsync(string code, int departmentId = 0);
    Task<bool> IsNameUniqueAsync(string name, int departmentId = 0);
}
