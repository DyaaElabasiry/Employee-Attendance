# Employee Attendance System

This is a complete Employee Attendance Management System built with ASP.NET Core MVC. It follows a clean, 3-tier architecture to manage departments, employees, and their attendance records.

---

## 📋 Features

* **Department Management**: Full CRUD (Create, Read, Update, Delete) operations for company departments.
* **Employee Management**: Full CRUD operations for employees.
* **Attendance Tracking**: (You can expand on this feature, e.g., "Log employee check-in and check-out times.")
* **Clean Architecture**: The solution is separated into Data, Business, and Web layers for maintainability and scalability.

---

## 🛠️ Technologies Used

* **Framework**: ASP.NET Core MVC (.NET 9)
* **Language**: C#
* **Database**: Entity Framework Core with In Memory db
* **Frontend**: HTML, CSS, JavaScript
* **UI Library**: Bootstrap 5
* **JavaScript Library**: jQuery

---

## 🏗️ Project Structure

The solution follows a 3-tier architecture:

* **`CodeZone.Attendance.Web`**: The main ASP.NET Core MVC project. It contains all the Controllers, Views (Razor Pages), ViewModels, and `wwwroot` static files (CSS, JS).
* **`CodeZone.Attendance.Business`**: The Business Logic Layer (BLL). This project handles the application's business rules and logic.
* **`CodeZone.Attendance.Data`**: The Data Access Layer (DAL). This project is responsible for all database interactions, using Entity Framework Core, repositories, and a `DbContext`.

---

## 🚀 Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download) (specify your version)
* [Visual Studio 2022](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload)

### Installation

1.  **Clone the repository:**
    ```sh
    git clone [https://github.com/DyaaElabasiry/Employee-Attendance.git](https://github.com/DyaaElabasiry/Employee-Attendance.git)
    ```
2.  **Open the solution:**
    * Navigate to the cloned folder and open `CodeZone.Attendance.sln` in Visual Studio.
5.  **Build and run the project:**
    * Press `Ctrl+F5` or the "Run" button (IIS Express) in Visual Studio to start the application.
    * Your browser will open automatically to the application's homepage.

