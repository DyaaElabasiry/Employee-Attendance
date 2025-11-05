using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Data.Repositories.Interfaces;

namespace CodeZone.Attendance.Data.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        public Task<AttendanceRecord> CreateOrUpdateAsync(int employeeId, DateTime date, AttendanceStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AttendanceRecord>> FilterAsync(int? departmentId, int? employeeId, DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AttendanceRecord>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AttendanceRecord> GetByEmployeeAndDateAsync(int employeeId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<AttendanceRecord> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<AttendanceRecord>> GetPagedAttendanceRecords(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
