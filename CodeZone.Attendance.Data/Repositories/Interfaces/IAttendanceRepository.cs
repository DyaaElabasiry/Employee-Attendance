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
    Task<IEnumerable<AttendanceRecord>> GetAllAsync();
    Task<PagedResult<AttendanceRecord>> GetPagedAttendanceRecords(int page, int pageSize);

    Task<AttendanceRecord> GetByIdAsync(int id);
    Task<AttendanceRecord> CreateOrUpdateAsync(int employeeId, DateTime date, AttendanceStatus status);
    Task<bool> DeleteAsync(int id);
    Task<AttendanceRecord> GetByEmployeeAndDateAsync(int employeeId, DateTime date);
    Task<List<AttendanceRecord>> FilterAsync(int? departmentId, int? employeeId, DateTime? from, DateTime? to);

}
