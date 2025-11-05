using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.Attendance.Data.Repositories.Interfaces;

public interface IAttendanceRepository
{
    Task<AttendanceRecord?> GetByIdAsync(int id);
    Task<AttendanceRecord?> GetByEmployeeAndDateAsync(int employeeId, DateTime date);
    Task<PagedResult<AttendanceRecord>> GetPagedAttendanceAsync(
        int page, 
        int pageSize, 
        int? departmentId = null, 
        int? employeeId = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null);
    Task<AttendanceRecord> AddAsync(AttendanceRecord attendance);
    Task<AttendanceRecord> UpdateAsync(AttendanceRecord attendance);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int employeeId, DateTime date, int? excludeId = null);
    Task<IEnumerable<AttendanceRecord>> GetByEmployeeIdAsync(int employeeId);
    Task<IEnumerable<AttendanceRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
}
