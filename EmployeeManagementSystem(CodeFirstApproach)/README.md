# Employee Management System

An ASP.NET MVC application for managing employee records, built with C#, .NET Framework 4.8, Entity Framework 6, and SQL Server.

## Features

- Employee management
- Employee registration and authentication
- Entity Framework Code First migrations

## Prerequisites

- Visual Studio with support for ASP.NET and .NET Framework projects
- .NET Framework 4.8 Developer Pack
- SQL Server or SQL Server Express
- NuGet package restore support

## Getting Started

1. Clone or download the repository.
2. Open `EmployeeManagementSystem(CodeFirstApproach).slnx` in Visual Studio.
3. Restore the NuGet dependencies.
4. Configure the `EmployeeContext` connection string in your local development environment.
5. Build the solution.
6. Ensure the development database is configured before running the application.

## Database

The application uses Entity Framework Code First migrations. Review the migration configuration and database connection settings before applying migrations.

## Development Workflow

Create a feature branch for each change, commit related changes with descriptive messages, and open a Pull Request for review.

## Security

Never commit passwords, access tokens, production connection strings, or real employee data.