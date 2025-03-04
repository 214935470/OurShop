# Dotnet WebAPI Project

## Overview

This project is a .NET WebAPI designed with a REST architecture, adhering strictly to REST principles.
It features a well-structured use of status codes and is divided into  layers,
each with a specific responsibility.

## Project Structure

The project is divided into the following layers:

- **Controller**: Manages the connection between the client and the server, handling error statuses.
- **Service**: Responsible for validations and business logic.
- **Repository**: Manages data access to the database.

### Layer Interaction

The layers communicate with each other through dependency injection. This approach ensures that the logic is written once and can be injected wherever needed in the project. Additionally, dependency injection allows for efficient project management; if a change is needed in the code, it can be made in one place. The logic for dependency injection is written in the `program.cs` file.

## Data Transfer Objects (DTOs)

The project uses DTOs defined as records since there is no need to modify the objects. The benefits of using DTOs include:

1. Removing circular dependencies between objects.
2. Allowing partial return or acceptance of objects for security purposes, etc.

### AutoMapper

Conversion between layers using DTOs is done via AutoMapper.

## Asynchronous Programming

The project utilizes the `async/await` mechanism to enhance scalability.

## Database

The database used is SQL, and EntityFramework is employed for ORM.

## Configuration Management

The `nconfig` file is used for managing configuration settings in the project. This allows for defining environment variables, application settings, and other configurations that can be easily updated or changed without modifying the main codebase. Examples include API keys and database connection strings, which are stored separately from the source code.

## Error Handling

All errors are handled using a logger. In case of a critical error, an alert email is sent.

## Rating

All requests to the site are saved in a `rating` table in the database for monitoring and rating purposes.

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Configure the `nconfig` file with your environment settings.
4. Run the application.

## Dependencies

- Dotnet 8.0
- EntityFramework
- AutoMapper

## License

This project is licensed under the MIT License.