using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeZone.Attendance.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "ENG", "Building A, Floor 3", "Engineering" },
                    { 2, "HR", "Building B, Floor 1", "Human Resources" },
                    { 3, "SAL", "Building A, Floor 2", "Sales" },
                    { 4, "MKT", "Building C, Floor 2", "Marketing" },
                    { 5, "FIN", "Building B, Floor 2", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, 1, "john.smith@codezone.com", "John Smith" },
                    { 2, 1, "sarah.johnson@codezone.com", "Sarah Johnson" },
                    { 3, 1, "michael.brown@codezone.com", "Michael Brown" },
                    { 4, 1, "emily.davis@codezone.com", "Emily Davis" },
                    { 5, 2, "david.wilson@codezone.com", "David Wilson" },
                    { 6, 2, "jennifer.martinez@codezone.com", "Jennifer Martinez" },
                    { 7, 3, "robert.anderson@codezone.com", "Robert Anderson" },
                    { 8, 3, "lisa.taylor@codezone.com", "Lisa Taylor" },
                    { 9, 3, "james.thomas@codezone.com", "James Thomas" },
                    { 10, 4, "mary.jackson@codezone.com", "Mary Jackson" },
                    { 11, 4, "chris.white@codezone.com", "Christopher White" },
                    { 12, 5, "patricia.harris@codezone.com", "Patricia Harris" },
                    { 13, 5, "daniel.martin@codezone.com", "Daniel Martin" }
                });

            migrationBuilder.InsertData(
                table: "AttendanceRecords",
                columns: new[] { "Id", "Date", "EmployeeId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 4, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 6, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 7, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 8, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 9, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 10, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 11, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 12, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 13, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 14, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 15, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 16, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 17, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 18, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 19, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 20, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 21, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 22, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 23, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 24, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 25, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 26, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 27, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 28, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 29, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 30, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 31, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 32, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 33, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 34, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 35, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 36, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 37, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 38, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 39, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 40, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 41, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 42, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 43, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 44, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 45, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 46, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 47, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 48, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 49, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 50, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 51, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 52, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 53, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 54, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 55, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 56, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 57, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 58, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 59, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 60, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 61, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 62, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 63, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 64, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 65, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 66, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 67, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 68, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 69, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 70, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 71, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 72, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 73, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 74, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 75, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 76, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 77, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 78, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 79, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 80, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 81, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 82, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 83, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 84, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 85, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 86, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 87, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 88, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 89, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 90, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 91, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 92, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 93, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 94, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 95, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 96, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 97, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 98, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 99, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 100, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 101, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 102, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 103, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 104, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 105, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 106, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 107, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 108, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 109, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 110, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 111, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 112, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 113, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 114, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 115, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 116, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 117, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 118, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 119, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 120, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 121, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 122, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 123, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 124, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 125, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 126, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 127, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 128, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 129, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 130, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 131, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 132, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 133, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 134, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 135, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 136, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 137, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 138, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 139, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 140, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 141, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2 },
                    { 142, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 143, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 144, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 145, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 146, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2 },
                    { 147, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 148, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 149, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 150, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 151, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2 },
                    { 152, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 153, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 154, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 155, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 156, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 157, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 158, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 159, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 160, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 161, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 162, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 163, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 164, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 165, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 166, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 167, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 168, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 169, new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 170, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 171, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 172, new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 173, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 174, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 175, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 176, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 177, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 178, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 179, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 180, new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 181, new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 182, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "AttendanceRecords",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
