using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.Attendance.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<PagedResult<Employee>> GetPagedEmployees(int page, int pageSize);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<bool> IsEmailUniqueAsync(int id, string email);
        Task<AttendanceSummary> GetAttendanceSummaryAsync(int employeeId);
    }
}
