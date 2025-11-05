using CodeZone.Attendance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeZone.Attendance.Data;

public class AttendanceDbContext : DbContext
{
    public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Department Configuration
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.Id);
            
            entity.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            entity.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(4);
            
            entity.Property(d => d.Location)
                .IsRequired()
                .HasMaxLength(100);

            // Unique constraints
            entity.HasIndex(d => d.Name).IsUnique();
            entity.HasIndex(d => d.Code).IsUnique();

            // Seed Departments
            entity.HasData(
                new Department { Id = 1, Name = "Engineering", Code = "ENGR", Location = "Building A, Floor 3" },
                new Department { Id = 2, Name = "Human Resources", Code = "HRMG", Location = "Building B, Floor 1" },
                new Department { Id = 3, Name = "Sales", Code = "SALE", Location = "Building A, Floor 2" },
                new Department { Id = 4, Name = "Marketing", Code = "MRKT", Location = "Building C, Floor 2" },
                new Department { Id = 5, Name = "Finance", Code = "FINC", Location = "Building B, Floor 2" }
            );
        });

        // Employee Configuration
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(200);
            
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

            // Unique constraints
            entity.HasIndex(e => e.Email).IsUnique();

            // Relationship with Department
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Employees
            entity.HasData(
                // Engineering Department
                new Employee { Id = 1, FullName = "John Michael Smith Anderson", Email = "john.smith@codezone.com", DepartmentId = 1 },
                new Employee { Id = 2, FullName = "Sarah Elizabeth Johnson Williams", Email = "sarah.johnson@codezone.com", DepartmentId = 1 },
                new Employee { Id = 3, FullName = "Michael James Brown Taylor", Email = "michael.brown@codezone.com", DepartmentId = 1 },
                new Employee { Id = 4, FullName = "Emily Rose Davis Martinez", Email = "emily.davis@codezone.com", DepartmentId = 1 },
                
                // HR Department
                new Employee { Id = 5, FullName = "David Robert Wilson Thompson", Email = "david.wilson@codezone.com", DepartmentId = 2 },
                new Employee { Id = 6, FullName = "Jennifer Marie Martinez Garcia", Email = "jennifer.martinez@codezone.com", DepartmentId = 2 },
                
                // Sales Department
                new Employee { Id = 7, FullName = "Robert Charles Anderson Moore", Email = "robert.anderson@codezone.com", DepartmentId = 3 },
                new Employee { Id = 8, FullName = "Lisa Anne Taylor Jackson", Email = "lisa.taylor@codezone.com", DepartmentId = 3 },
                new Employee { Id = 9, FullName = "James William Thomas White", Email = "james.thomas@codezone.com", DepartmentId = 3 },
                
                // Marketing Department
                new Employee { Id = 10, FullName = "Mary Catherine Jackson Harris", Email = "mary.jackson@codezone.com", DepartmentId = 4 },
                new Employee { Id = 11, FullName = "Christopher John White Martin", Email = "chris.white@codezone.com", DepartmentId = 4 },
                
                // Finance Department
                new Employee { Id = 12, FullName = "Patricia Lynn Harris Thompson", Email = "patricia.harris@codezone.com", DepartmentId = 5 },
                new Employee { Id = 13, FullName = "Daniel Patrick Martin Clark", Email = "daniel.martin@codezone.com", DepartmentId = 5 }
            );
        });

        // AttendanceRecord Configuration
        modelBuilder.Entity<AttendanceRecord>(entity =>
        {
            entity.HasKey(a => a.Id);
            
            entity.Property(a => a.Date)
                .IsRequired()
                .HasColumnType("date");
            
            entity.Property(a => a.Status)
                .IsRequired()
                .HasConversion<int>();

            // Unique constraint: one attendance per employee per day
            entity.HasIndex(a => new { a.EmployeeId, a.Date }).IsUnique();

            // Relationship with Employee
            entity.HasOne(a => a.Employee)
                .WithMany(e => e.AttendanceRecords)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Attendance Records (Current month data)
            var today = DateTime.Today;
            var currentMonth = today.Month;
            var currentYear = today.Year;
            var firstDayOfMonth = new DateTime(currentYear, currentMonth, 1);
            
            var attendanceRecords = new List<AttendanceRecord>();
            int recordId = 1;

            // Generate attendance for the first 20 days of current month for all employees
            for (int employeeId = 1; employeeId <= 13; employeeId++)
            {
                for (int day = 1; day <= Math.Min(20, DateTime.DaysInMonth(currentYear, currentMonth)); day++)
                {
                    var date = new DateTime(currentYear, currentMonth, day);
                    
                    // Skip weekends
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        continue;

                    // 85% attendance rate (random absences)
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

            entity.HasData(attendanceRecords);
        });
    }
}