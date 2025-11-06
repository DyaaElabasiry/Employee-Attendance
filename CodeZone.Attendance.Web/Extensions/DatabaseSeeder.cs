using CodeZone.Attendance.Data;
using CodeZone.Attendance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeZone.Attendance.Web.Extensions;

public static class DatabaseSeeder
{
    public static void SeedDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AttendanceDbContext>();

        // Ensure database is created
        context.Database.EnsureCreated();

        // Check if data already exists
        if (context.Departments.Any())
        {
            return; // Database has been seeded
        }

        SeedDepartments(context);
        SeedEmployees(context);
        SeedAttendanceRecords(context);

        context.SaveChanges();
    }

    private static void SeedDepartments(AttendanceDbContext context)
    {
        var departments = new List<Department>
        {
            new Department { Id = 1, Name = "Engineering", Code = "ENG", Location = "Building A, Floor 3" },
            new Department { Id = 2, Name = "Human Resources", Code = "HR", Location = "Building B, Floor 1" },
            new Department { Id = 3, Name = "Sales", Code = "SAL", Location = "Building A, Floor 2" },
            new Department { Id = 4, Name = "Marketing", Code = "MKT", Location = "Building C, Floor 2" },
            new Department { Id = 5, Name = "Finance", Code = "FIN", Location = "Building B, Floor 2" }
        };

        context.Departments.AddRange(departments);
        context.SaveChanges();
    }

    private static void SeedEmployees(AttendanceDbContext context)
    {
        var employees = new List<Employee>
        {
            // Engineering Department
            new Employee { Id = 1, FullName = "John Smith", Email = "john.smith@codezone.com", DepartmentId = 1 },
            new Employee { Id = 2, FullName = "Sarah Johnson", Email = "sarah.johnson@codezone.com", DepartmentId = 1 },
            new Employee { Id = 3, FullName = "Michael Brown", Email = "michael.brown@codezone.com", DepartmentId = 1 },
            new Employee { Id = 4, FullName = "Emily Davis", Email = "emily.davis@codezone.com", DepartmentId = 1 },
            
            // HR Department
            new Employee { Id = 5, FullName = "David Wilson", Email = "david.wilson@codezone.com", DepartmentId = 2 },
            new Employee { Id = 6, FullName = "Jennifer Martinez", Email = "jennifer.martinez@codezone.com", DepartmentId = 2 },
            
            // Sales Department
            new Employee { Id = 7, FullName = "Robert Anderson", Email = "robert.anderson@codezone.com", DepartmentId = 3 },
            new Employee { Id = 8, FullName = "Lisa Taylor", Email = "lisa.taylor@codezone.com", DepartmentId = 3 },
            new Employee { Id = 9, FullName = "James Thomas", Email = "james.thomas@codezone.com", DepartmentId = 3 },
            
            // Marketing Department
            new Employee { Id = 10, FullName = "Mary Jackson", Email = "mary.jackson@codezone.com", DepartmentId = 4 },
            new Employee { Id = 11, FullName = "Christopher White", Email = "chris.white@codezone.com", DepartmentId = 4 },
            
            // Finance Department
            new Employee { Id = 12, FullName = "Patricia Harris", Email = "patricia.harris@codezone.com", DepartmentId = 5 },
            new Employee { Id = 13, FullName = "Daniel Martin", Email = "daniel.martin@codezone.com", DepartmentId = 5 }
        };

        context.Employees.AddRange(employees);
        context.SaveChanges();
    }

    private static void SeedAttendanceRecords(AttendanceDbContext context)
    {
        var attendanceRecords = new List<AttendanceRecord>();
        int recordId = 1;

        // Generate attendance records for November 2025
        var year = 2025;
        var month = 11;
        
        // Days to generate attendance for (weekdays only in November 2025)
        var workDays = new List<int> { 3, 4, 5, 6, 7, 10, 11, 12, 13, 14, 17, 18, 19, 20 };

        for (int employeeId = 1; employeeId <= 13; employeeId++)
        {
            foreach (var day in workDays)
            {
                var date = new DateTime(year, month, day);
                
                // Create a pattern for absences (roughly 15% absence rate)
                var status = (employeeId + day) % 7 == 0 ? AttendanceStatus.Absent : AttendanceStatus.Present;
                
                attendanceRecords.Add(new AttendanceRecord
                {
                    Id = recordId++,
                    EmployeeId = employeeId,
                    Date = date,
                    Status = status
                });
            }
        }

        context.AttendanceRecords.AddRange(attendanceRecords);
        context.SaveChanges();
    }
}