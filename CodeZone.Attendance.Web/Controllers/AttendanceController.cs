using CodeZone.Attendance.Business.Interfaces;
using CodeZone.Attendance.Data.Entities;
using CodeZone.Attendance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeZone.Attendance.Web.Controllers;

public class AttendanceController : Controller
{
    private readonly IAttendanceService _attendanceService;
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public AttendanceController(
        IAttendanceService attendanceService,
        IEmployeeService employeeService,
        IDepartmentService departmentService)
    {
        _attendanceService = attendanceService;
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    // GET: /Attendance or /Attendance/Index
    public async Task<IActionResult> Index(
        int page = 1, 
        int? departmentId = null, 
        int? employeeId = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null)
    {
        await PopulateDropdowns();
        
        ViewBag.DepartmentId = departmentId;
        ViewBag.EmployeeId = employeeId;
        ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
        ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
        ViewBag.Page = page;

        return View();
    }

    // GET: /Attendance/AttendanceList - Partial view for attendance list
    public async Task<IActionResult> AttendanceList(
        int page = 1, 
        int pageSize = 10,
        int? departmentId = null, 
        int? employeeId = null, 
        DateTime? startDate = null, 
        DateTime? endDate = null)
    {
        var pagedViewModel = await _attendanceService.GetPagedAttendanceListAsync(
            page, 
            pageSize, 
            departmentId, 
            employeeId, 
            startDate, 
            endDate);

        return PartialView("_AttendanceListPartial", pagedViewModel);
    }

    // GET: /Attendance/GetAttendanceStatus - AJAX endpoint
    [HttpGet]
    public async Task<IActionResult> GetAttendanceStatus(int employeeId, DateTime date)
    {
        if (employeeId == 0 || date == DateTime.MinValue)
        {
            return Json(new { success = false, message = "Invalid parameters" });
        }

        var attendance = await _attendanceService.GetAttendanceByEmployeeAndDateAsync(employeeId, date);
        
        if (attendance == null)
        {
            return Json(new 
            { 
                success = true, 
                exists = false, 
                status = "Not marked",
                statusValue = -1,
                employeeId = employeeId,
                date = date.ToString("yyyy-MM-dd")
            });
        }

        return Json(new 
        { 
            success = true, 
            exists = true,
            id = attendance.Id,
            status = attendance.Status.ToString(),
            statusValue = (int)attendance.Status,
            employeeId = attendance.EmployeeId,
            date = attendance.Date.ToString("yyyy-MM-dd")
        });
    }

    // GET: /Attendance/Create
    public async Task<IActionResult> Create()
    {
        var model = await _attendanceService.GetAttendanceFormViewModelAsync();
        await PopulateDropdowns();
        return View(model);
    }

    // POST: /Attendance/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AttendanceFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropdowns();
            return View(model);
        }

        var validationResult = await _attendanceService.ValidateAttendanceAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }
            await PopulateDropdowns();
            return View(model);
        }

        var success = await _attendanceService.CreateAttendanceAsync(model);

        if (success)
        {
            TempData["SuccessMessage"] = "Attendance recorded successfully!";
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError("", "An error occurred while recording attendance.");
        await PopulateDropdowns();
        return View(model);
    }

    // POST: /Attendance/MarkAttendance - AJAX endpoint for quick marking
    [HttpPost]
    public async Task<IActionResult> MarkAttendance(int employeeId, DateTime date, int status)
    {
        if (employeeId == 0 || date == DateTime.MinValue)
        {
            return Json(new { success = false, message = "Invalid parameters" });
        }

        if (date.Date > DateTime.Today)
        {
            return Json(new { success = false, message = "Cannot mark attendance for future dates" });
        }

        var model = new AttendanceFormViewModel
        {
            EmployeeId = employeeId,
            Date = date,
            Status = (AttendanceStatus)status
        };

        var validationResult = await _attendanceService.ValidateAttendanceAsync(model);
        if (!validationResult.IsValid)
        {
            var firstError = validationResult.Errors.FirstOrDefault();
            return Json(new { success = false, message = firstError.Value });
        }

        var success = await _attendanceService.CreateAttendanceAsync(model);

        if (success)
        {
            return Json(new { success = true, message = "Attendance marked successfully" });
        }

        return Json(new { success = false, message = "Failed to mark attendance" });
    }

    // GET: /Attendance/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var model = await _attendanceService.GetAttendanceByIdAsync(id);
        
        if (model == null)
        {
            TempData["ErrorMessage"] = "Attendance record not found.";
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropdowns();
        return View(model);
    }

    // POST: /Attendance/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, AttendanceFormViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            await PopulateDropdowns();
            return View(model);
        }

        var validationResult = await _attendanceService.ValidateAttendanceAsync(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }
            await PopulateDropdowns();
            return View(model);
        }

        var success = await _attendanceService.UpdateAttendanceAsync(model);

        if (success)
        {
            TempData["SuccessMessage"] = "Attendance updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMessage"] = "Attendance record not found or an error occurred.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Attendance/UpdateAttendance - AJAX endpoint for updating
    [HttpPost]
    public async Task<IActionResult> UpdateAttendance(int id, int status)
    {
        var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
        
        if (attendance == null)
        {
            return Json(new { success = false, message = "Attendance record not found" });
        }

        attendance.Status = (AttendanceStatus)status;

        var success = await _attendanceService.UpdateAttendanceAsync(attendance);

        if (success)
        {
            return Json(new { success = true, message = "Attendance updated successfully" });
        }

        return Json(new { success = false, message = "Failed to update attendance" });
    }

    // POST: /Attendance/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _attendanceService.DeleteAttendanceAsync(id);
        
        if (success)
        {
            TempData["SuccessMessage"] = "Attendance record deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Attendance record not found or an error occurred.";
        }

        return RedirectToAction(nameof(Index));
    }

    // POST: /Attendance/DeleteAttendance - AJAX endpoint
    [HttpPost]
    public async Task<IActionResult> DeleteAttendance(int id)
    {
        var success = await _attendanceService.DeleteAttendanceAsync(id);
        
        if (success)
        {
            return Json(new { success = true, message = "Attendance deleted successfully" });
        }

        return Json(new { success = false, message = "Failed to delete attendance" });
    }

    private async Task PopulateDropdowns()
    {
        ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();
        ViewBag.Employees = await _employeeService.GetAllEmployeesAsync();
    }
}