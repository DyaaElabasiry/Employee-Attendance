using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeZone.Attendance.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AttendanceDbContext _context;

    public DepartmentRepository(AttendanceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments
            .Include(d => d.Employees)
            .OrderBy(d => d.Name)
            .ToListAsync();
    }

    public async Task<PagedResult<Department>> GetPagedDepartments(int page, int pageSize)
    {
        var total = await _context.Departments.CountAsync();
        var departments = await _context.Departments
            .Include(d => d.Employees)
            .OrderBy(d => d.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Department>
        {
            Items = departments,
            Page = page,
            PageSize = pageSize,
            TotalCount = total
        };
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _context.Departments
            .Include(d => d.Employees)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Department> AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department> UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        
        if (department == null)
            return false;

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<int> GetEmployeeCountAsync(int departmentId)
    {
        return await _context.Employees
            .CountAsync(e => e.DepartmentId == departmentId);
    }

    public async Task<bool> IsCodeUniqueAsync(int id, string code)
    {
        return !await _context.Departments
            .AnyAsync(d => d.Code == code && d.Id != id);
    }

    public async Task<bool> IsNameUniqueAsync(int id, string name)
    {
        return !await _context.Departments
            .AnyAsync(d => d.Name == name && d.Id != id);
    }
}
