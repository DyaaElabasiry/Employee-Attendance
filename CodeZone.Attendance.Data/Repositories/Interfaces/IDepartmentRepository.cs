using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.Attendance.Data.Repositories.Interfaces;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllAsync();
    Task<PagedResult<Department>> GetPagedDepartments(int page, int pageSize);

    Task<Department> GetByIdAsync(int id);
    Task<Department> AddAsync(Department department);
    Task<Department> UpdateAsync(Department department);
    Task<bool> DeleteAsync(int id);
    Task<int> GetEmployeeCountAsync(int departmentId);
    Task<bool> IsCodeUniqueAsync(int id, string code);
    Task<bool> IsNameUniqueAsync(int id, string name);
}
