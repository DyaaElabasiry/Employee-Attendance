using CodeZone.Attendance.Business.Models;
using CodeZone.Attendance.Data.Models;
using CodeZone.Attendance.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.Attendance.Business.Interfaces
{
    public interface IAttendanceService
    {
        Task<PagedResult<AttendanceListViewModel>> GetPagedAttendanceListAsync(
            int page, 
            int pageSize, 
            int? departmentId = null, 
            int? employeeId = null, 
            DateTime? startDate = null, 
            DateTime? endDate = null);
        
        Task<AttendanceFormViewModel?> GetAttendanceByIdAsync(int id);
        Task<AttendanceFormViewModel?> GetAttendanceByEmployeeAndDateAsync(int employeeId, DateTime date);
        Task<AttendanceFormViewModel> GetAttendanceFormViewModelAsync();
        Task<bool> CreateAttendanceAsync(AttendanceFormViewModel model);
        Task<bool> UpdateAttendanceAsync(AttendanceFormViewModel model);
        Task<bool> DeleteAttendanceAsync(int id);
        Task<ValidationResult> ValidateAttendanceAsync(AttendanceFormViewModel model);
    }
}
