using CodeZone.Attendance.Business.Interfaces;
using CodeZone.Attendance.Business.Models;
using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Data.Repositories.Interfaces;
using CodeZone.Attendance.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.Attendance.Business
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepo;

        public AttendanceService(IAttendanceRepository attendanceRepo)
        {
            _attendanceRepo = attendanceRepo;
        }

        public async Task<PagedResult<AttendanceListViewModel>> GetPagedAttendanceListAsync(
            int page, 
            int pageSize, 
            int? departmentId = null, 
            int? employeeId = null, 
            DateTime? startDate = null, 
            DateTime? endDate = null)
        {
            // Get paginated entities from repository with filters
            var pagedAttendanceEntities = await _attendanceRepo.GetPagedAttendanceAsync(
                page, 
                pageSize, 
                departmentId, 
                employeeId, 
                startDate, 
                endDate);

            // Map entities to view models
            var attendanceViewModels = pagedAttendanceEntities.Items.Select(att => new AttendanceListViewModel
            {
                Id = att.Id,
                EmployeeId = att.EmployeeId,
                EmployeeName = att.Employee.FullName,
                DepartmentName = att.Employee.Department.Name,
                Date = att.Date,
                Status = att.Status,
                StatusDisplay = att.Status.ToString()
            }).ToList();

            // Create paged result for view models
            return new PagedResult<AttendanceListViewModel>
            {
                Items = attendanceViewModels,
                Page = pagedAttendanceEntities.Page,
                PageSize = pagedAttendanceEntities.PageSize,
                TotalCount = pagedAttendanceEntities.TotalCount
            };
        }

        public async Task<AttendanceFormViewModel?> GetAttendanceByIdAsync(int id)
        {
            var attendance = await _attendanceRepo.GetByIdAsync(id);
            
            if (attendance == null)
                return null;

            return new AttendanceFormViewModel
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                Date = attendance.Date,
                Status = attendance.Status
            };
        }

        public async Task<AttendanceFormViewModel?> GetAttendanceByEmployeeAndDateAsync(int employeeId, DateTime date)
        {
            var attendance = await _attendanceRepo.GetByEmployeeAndDateAsync(employeeId, date);
            
            if (attendance == null)
                return null;

            return new AttendanceFormViewModel
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                Date = attendance.Date,
                Status = attendance.Status
            };
        }

        public Task<AttendanceFormViewModel> GetAttendanceFormViewModelAsync()
        {
            // Return empty form model for create
            return Task.FromResult(new AttendanceFormViewModel
            {
                Date = DateTime.Today
            });
        }

        public async Task<bool> CreateAttendanceAsync(AttendanceFormViewModel model)
        {
            // Business logic validation
            var validationResult = await ValidateAttendanceAsync(model);
            if (!validationResult.IsValid)
                return false;

            var attendance = new AttendanceRecord
            {
                EmployeeId = model.EmployeeId,
                Date = model.Date.Date,
                Status = model.Status
            };

            await _attendanceRepo.AddAsync(attendance);
            return true;
        }

        public async Task<bool> UpdateAttendanceAsync(AttendanceFormViewModel model)
        {
            // Business logic: Check if attendance exists
            var attendance = await _attendanceRepo.GetByIdAsync(model.Id);
            
            if (attendance == null)
                return false;

            // Business logic validation
            var validationResult = await ValidateAttendanceAsync(model);
            if (!validationResult.IsValid)
                return false;

            // Update entity properties
            attendance.EmployeeId = model.EmployeeId;
            attendance.Date = model.Date.Date;
            attendance.Status = model.Status;

            await _attendanceRepo.UpdateAsync(attendance);
            return true;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            // Business logic: Check if attendance exists
            var attendance = await _attendanceRepo.GetByIdAsync(id);
            
            if (attendance == null)
                return false;

            return await _attendanceRepo.DeleteAsync(id);
        }

        public async Task<ValidationResult> ValidateAttendanceAsync(AttendanceFormViewModel model)
        {
            var result = ValidationResult.Success();

            // Business Rule: Cannot mark attendance for future dates
            if (model.Date.Date > DateTime.Today)
            {
                result.AddError("Date", "Attendance cannot be marked for future dates.");
            }

            // Business Rule: Each employee has only one attendance per day
            var exists = await _attendanceRepo.ExistsAsync(model.EmployeeId, model.Date, model.Id > 0 ? model.Id : null);
            if (exists)
            {
                result.AddError("Date", "Attendance for this employee on this date already exists.");
            }

            return result;
        }
    }
}
