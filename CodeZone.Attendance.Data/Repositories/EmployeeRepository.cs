using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.Attendance.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AttendanceDbContext _context;

        public EmployeeRepository(AttendanceDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
                         .Include(e => e.Department)
                         .Include(e => e.AttendanceRecords)
                         .ToListAsync();
        }

        public Task<AttendanceSummary> GetAttendanceSummaryAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<PagedResult<Employee>> GetPagedEmployees(int page, int pageSize)
        {
            var total = await _context.Employees.CountAsync();
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.AttendanceRecords)
                .OrderBy(e => e.FullName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PagedResult<Employee>() { Items = employees, Page = page, PageSize = pageSize, TotalCount = total };
        }

        public Task<bool> IsEmailUniqueAsync(int id, string email)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
