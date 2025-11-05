using CodeZone.Attendance.Business.Interfaces;
using CodeZone.Attendance.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeZone.Attendance.Web.Controllers;

public class DepartmentsController : Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // GET: /Departments or /Departments/Index
    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();
        return View(departments);
    }

    // GET: /Departments/Create
    public async Task<IActionResult> Create()
    {
        var model = await _departmentService.GetDepartmentFormViewModelAsync();
        return View(model);
    }

    // POST: /Departments/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DepartmentFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Check code uniqueness
        var isCodeUnique = await _departmentService.IsCodeUniqueAsync(model.Code);
        if (!isCodeUnique)
        {
            ModelState.AddModelError("Code", "This department code is already in use.");
            return View(model);
        }

        // Check name uniqueness
        var isNameUnique = await _departmentService.IsNameUniqueAsync(model.Name);
        if (!isNameUnique)
        {
            ModelState.AddModelError("Name", "This department name is already in use.");
            return View(model);
        }

        var success = await _departmentService.CreateDepartmentAsync(model);
        
        if (success)
        {
            TempData["SuccessMessage"] = "Department created successfully!";
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError("", "An error occurred while creating the department.");
        return View(model);
    }

    // GET: /Departments/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var model = await _departmentService.GetDepartmentForEditAsync(id);
     
        return View(model);
    }

    // POST: /Departments/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DepartmentFormViewModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Check code uniqueness
        var isCodeUnique = await _departmentService.IsCodeUniqueAsync(model.Code, model.Id);
        if (!isCodeUnique)
        {
            ModelState.AddModelError("Code", "This department code is already in use.");
            return View(model);
        }

        // Check name uniqueness
        var isNameUnique = await _departmentService.IsNameUniqueAsync(model.Name, model.Id);
        if (!isNameUnique)
        {
            ModelState.AddModelError("Name", "This department name is already in use.");
            return View(model);
        }

        var success = await _departmentService.UpdateDepartmentAsync(model);
        
        if (success)
        {
            TempData["SuccessMessage"] = "Department updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMessage"] = "Department not found or an error occurred.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Departments/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _departmentService.DeleteDepartmentAsync(id);
        
        if (success)
        {
            TempData["SuccessMessage"] = "Department deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Cannot delete department. It may have employees or does not exist.";
        }

        return RedirectToAction(nameof(Index));
    }
}