using CodeZone.Attendance.Business;
using CodeZone.Attendance.Business.Interfaces;
using CodeZone.Attendance.Data;
using CodeZone.Attendance.Data.Repositories;
using CodeZone.Attendance.Data.Repositories.Interfaces;
using CodeZone.Attendance.Web.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
// Register DbContext
builder.Services.AddDbContext<AttendanceDbContext>(options =>
    options.UseInMemoryDatabase("EmployeeAttendanceDB"));

var app = builder.Build();

// Seed the database
app.Services.SeedDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
