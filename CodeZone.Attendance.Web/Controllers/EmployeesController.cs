using CodeZone.Attendance.Business.Interfaces;
using CodeZone.Attendance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeZone.Attendance.Web.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    // Handles GET: /Employees or /Employees/Index
    public async Task<IActionResult> Index(int page = 1) // Default to page 1
    {
        // 1. Call the service
        var pagedViewModel = await _employeeService.GetPagedEmployeeListAsync(page, 10);

        // 2. Pass the entire paged result directly to the view
        return View(pagedViewModel);
    }

    // GET: /Employees/Create
    public async Task<IActionResult> Create()
    {
        var model = await _employeeService.GetEmployeeFormViewModelAsync();
        await PopulateDepartments();
        return View(model);
    }

    // POST: /Employees/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeFormViewModel model)
    {
        await PopulateDepartments();
        if (!ModelState.IsValid)
        {
            // Reload departments if validation fails
            await PopulateDepartments();
            return View(model);
        }

        // Check email uniqueness
        var isEmailUnique = await _employeeService.IsEmailUniqueAsync(model.Email);
        if (!isEmailUnique)
        {
            ModelState.AddModelError("Email", "This email address is already in use.");
            await PopulateDepartments();
            return View(model);
        }

        var success = await _employeeService.CreateEmployeeAsync(model);
        
        if (success)
        {
            TempData["SuccessMessage"] = "Employee created successfully!";
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError("", "An error occurred while creating the employee.");
        await PopulateDepartments();
        return View(model);
    }

    // GET: /Employees/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var model = await _employeeService.GetEmployeeByIdAsync(id);
        await PopulateDepartments();
        return View(model);
    }

    // POST: /Employees/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EmployeeFormViewModel model)
    {
        
        if (id != model.Id)
        {
            return BadRequest();
        }
        
        if (!ModelState.IsValid)
        {
            // Reload departments if validation fails
            var formModel = await _employeeService.GetEmployeeByIdAsync(id);
            await PopulateDepartments();
            return View(model);
        }

        // Check email uniqueness
        var isEmailUnique = await _employeeService.IsEmailUniqueAsync(model.Email, model.Id);
        if (!isEmailUnique)
        {
            ModelState.AddModelError("Email", "This email address is already in use.");
            var formModel = await _employeeService.GetEmployeeByIdAsync(id);
            await PopulateDepartments();
            return View(model);
        }

        var success = await _employeeService.UpdateEmployeeAsync(model);
        
        if (success)
        {
            TempData["SuccessMessage"] = "Employee updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMessage"] = "Employee not found or an error occurred.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Employees/Delete/5
    public async Task<IActionResult> Delete(int id,int page)
    {
        try
        {
            await _employeeService.DeleteEmployeeAsync(id);
            TempData["SuccessMessage"] = "Employee deleted successfully!";
        }
        catch
        {
            TempData["ErrorMessage"] = "An error occurred while deleting the employee.";
        }

        return RedirectToAction(nameof(Index), new { page });
    }
    public async Task PopulateDepartments()
    {
        
        ViewBag.Departments = await _departmentService.GetAllDepartmentsAsync();
    }
}
