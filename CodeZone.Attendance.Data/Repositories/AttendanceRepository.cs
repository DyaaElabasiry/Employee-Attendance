using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeZone.Attendance.Data.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceDbContext _context;

        public AttendanceRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<AttendanceRecord?> GetByIdAsync(int id)
        {
            return await _context.AttendanceRecords
                .Include(a => a.Employee)
                    .ThenInclude(e => e.Department)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AttendanceRecord?> GetByEmployeeAndDateAsync(int employeeId, DateTime date)
        {
            return await _context.AttendanceRecords
                .Include(a => a.Employee)
                    .ThenInclude(e => e.Department)
                .FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.Date.Date == date.Date);
        }

        public async Task<PagedResult<AttendanceRecord>> GetPagedAttendanceAsync(
            int page, 
            int pageSize, 
            int? departmentId = null, 
            int? employeeId = null, 
            DateTime? startDate = null, 
            DateTime? endDate = null)
        {
            var query = _context.AttendanceRecords
                .Include(a => a.Employee)
                    .ThenInclude(e => e.Department)
                .AsQueryable();

            // Apply filters
            if (departmentId.HasValue)
            {
                query = query.Where(a => a.Employee.DepartmentId == departmentId.Value);
            }

            if (employeeId.HasValue)
            {
                query = query.Where(a => a.EmployeeId == employeeId.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(a => a.Date >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                query = query.Where(a => a.Date <= endDate.Value.Date);
            }

            var total = await query.CountAsync();
            
            var attendanceRecords = await query
                .OrderByDescending(a => a.Date)
                .ThenBy(a => a.Employee.FullName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<AttendanceRecord>
            {
                Items = attendanceRecords,
                Page = page,
                PageSize = pageSize,
                TotalCount = total
            };
        }

        public async Task<AttendanceRecord> AddAsync(AttendanceRecord attendance)
        {
            await _context.AttendanceRecords.AddAsync(attendance);
            await _context.SaveChangesAsync();
            
            // Reload with navigation properties
            return await GetByIdAsync(attendance.Id) ?? attendance;
        }

        public async Task<AttendanceRecord> UpdateAsync(AttendanceRecord attendance)
        {
            _context.AttendanceRecords.Update(attendance);
            await _context.SaveChangesAsync();
            
            // Reload with navigation properties
            return await GetByIdAsync(attendance.Id) ?? attendance;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attendance = await _context.AttendanceRecords.FindAsync(id);
            
            if (attendance == null)
                return false;

            _context.AttendanceRecords.Remove(attendance);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> ExistsAsync(int employeeId, DateTime date, int? excludeId = null)
        {
            return await _context.AttendanceRecords
                .AnyAsync(a => a.EmployeeId == employeeId 
                    && a.Date.Date == date.Date 
                    && (!excludeId.HasValue || a.Id != excludeId.Value));
        }

        public async Task<IEnumerable<AttendanceRecord>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.AttendanceRecords
                .Include(a => a.Employee)
                    .ThenInclude(e => e.Department)
                .Where(a => a.EmployeeId == employeeId)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<AttendanceRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.AttendanceRecords
                .Include(a => a.Employee)
                    .ThenInclude(e => e.Department)
                .Where(a => a.Date >= startDate.Date && a.Date <= endDate.Date)
                .OrderByDescending(a => a.Date)
                .ThenBy(a => a.Employee.FullName)
                .ToListAsync();
        }
    }
}
