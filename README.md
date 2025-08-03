# StudentManagementApi

A RESTful API for managing students using ASP.NET Core Web API and SQL Server.  
This project demonstrates clean architecture practices including separation of concerns, exception handling, and custom exception logic.

## 📚 Features

- Add, update, delete, and retrieve student data.
- Custom exception handling and structured error responses.
- Logging using built-in .NET Core logging mechanisms.
- SQL Server database integration using Entity Framework Core.

## 🧱 Project Structure

- **Controllers/** – Handles HTTP requests and responses.
- **Models/** – Contains the Student model class.
- **Services/** – Contains the business logic for managing students.
- **CustomExceptions/** – Defines custom exceptions used across the app.
- **Middlewares/** – Handles global exception handling.
- **Data/** – Includes the AppDbContext class for EF Core.

## 🛠️ Tech Stack

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core
- SQL Server (SSMS)
- Visual Studio 2022

## 🏁 How to Run the Project

1. **Clone the Repository**
   ```bash
   git clone https://github.com/YourUsername/StudentManagementApi.git
   cd StudentManagementApi
