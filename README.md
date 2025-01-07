# Clean Architecture & Azure for Scalable APIs in ASP.NET Core 8

This project is a comprehensive implementation of a robust, high-performance RESTful API using **ASP.NET Core 8**, **Clean Architecture**, and **Azure services**. It demonstrates how to build scalable, maintainable, and secure web APIs by leveraging modern development practices and cloud technologies. Below is an overview of the project's structure, features, and technologies used.

---

## Table of Contents
1. [Project Overview](#project-overview)
2. [Technologies Used](#technologies-used)
3. [Features](#features)
4. [Project Structure](#project-structure)
5. [Getting Started](#getting-started)

---

## Project Overview

This project is designed to showcase the best practices for building RESTful APIs using **Clean Architecture** principles. It includes features like user authentication, resource management, logging, automated documentation, and deployment to Azure. The API is built with scalability and maintainability in mind, making it suitable for real-world applications.

---

## Technologies Used

- **ASP.NET Core 8**: The core framework for building the API.
- **Clean Architecture**: A design pattern for organizing code into layers (Domain, Application, Infrastructure, Presentation).
- **Entity Framework Core**: For database interactions and migrations.
- **MS SQL Server**: The primary database for storing application data.
- **Azure Services**: Includes Azure App Service for hosting and Azure SQL for database management.
- **MediatR**: For implementing the Command/Query Responsibility Segregation (CQRS) pattern.
- **Fluent Validation**: For validating incoming requests.
- **Serilog**: For structured logging and event tracking.
- **Swagger/OpenAPI**: For automated API documentation.
- **ASP.NET Identity**: For user authentication and authorization.
- **xUnit**: For unit and integration testing.
- **Azure DevOps**: For CI/CD pipelines.

---

## Features

### Core Functionality
- **RESTful Resource Management**: CRUD operations for resources following REST best practices.
- **DTO Mapping**: Efficient data transfer between layers using AutoMapper.
- **Validation**: Robust request validation with Fluent Validation.
- **CQRS Pattern**: Separation of commands and queries using MediatR.

### Advanced Features
- **Sub-Entity Management**: Handling nested resources within main entities.
- **User Authentication & Authorization**: Secure API endpoints using ASP.NET Identity with roles and custom claims.
- **Pagination & Sorting**: Optimized data retrieval for large datasets.
- **Global Exception Handling**: Centralized error handling for consistent error responses.

### Operational Excellence
- **Logging**: Structured logging with Serilog for troubleshooting and monitoring.
- **Automated Documentation**: Swagger/OpenAPI integration for easy API exploration.
- **Unit & Integration Testing**: Comprehensive test coverage using xUnit.
- **Azure Deployment**: Scalable cloud hosting with Azure App Service and Azure SQL.

---

## Project Structure

The project follows the **Clean Architecture** pattern, organized into the following layers:

1. **Domain**: Contains the core business logic, entities, and interfaces.
2. **Application**: Implements use cases, commands, queries, and validations.
3. **Infrastructure**: Handles external concerns like database access, logging, and authentication.
4. **Presentation**: The API layer with controllers, middleware, and Swagger documentation.

```bash
CleanArchitectureAPI/
├── Domain/
│   ├── Entities/
│   ├── Interfaces/
├── Application/
│   ├── Commands/
│   ├── Queries/
│   ├── Validations/
├── Infrastructure/
│   ├── Data/
│   ├── Identity/
│   ├── Logging/
├── Presentation/
│   ├── Controllers/
│   ├── Middleware/
│   ├── Extensions/
```
## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code
- SQL Server (or Azure SQL)
- Azure Account (for deployment)

### Installation
1. Clone the repository:
   ```bash
     git clone https://github.com/buraxta/Restaurants-DotnetCore.git
   ```
2. Navigate to the project directory:
   ```bash
     cd CleanArchitectureAPI
   ```
3. Restore dependencies:
    ```bash
      dotnet restore
    ```
4. Update the database connection string in **appsettings.json**.

5. Run database migrations:
   ```bash
     dotnet ef database update
   ```
6. Start the application:
   ```bash
     dotnet run
   ```
