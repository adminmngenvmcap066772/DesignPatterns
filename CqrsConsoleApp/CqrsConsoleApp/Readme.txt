# CQRS Demo Solution Overview

This solution demonstrates the Command Query Responsibility Segregation (CQRS) pattern in C# (.NET 9). The code is organized into folders for Commands, Queries, Handlers, Entities, Repositories, and Interfaces.

## How the Code Works

### 1. Command Side (Write)
- **CreateUserCommand**: Represents a request to create a new user. It contains the user's name.
- **CreateUserCommandHandler**: Handles the CreateUserCommand. It uses the UserRepository to add a new user and returns the created User object.
- **ICommandHandler<TCommand, TResponse>**: Generic interface for command handlers.

### 2. Query Side (Read)
- **GetUserQuery**: Represents a request to retrieve a user by ID.
- **GetUserQueryHandler**: Handles the GetUserQuery. It uses the UserRepository to fetch a user by their ID.
- **IQueryHandler<TQuery, TResponse>**: Generic interface for query handlers.

### 3. Shared Components
- **User**: Entity representing a user (with Id and Name).
- **UserRepository**: In-memory repository for storing and retrieving users.

### 4. Program.cs (Demo Entry Point)
- Instantiates the UserRepository.
- Uses CreateUserCommandHandler to create a new user.
- Uses GetUserQueryHandler to retrieve the user by ID.
- Outputs the results to the console.

### 5. Folder Structure
- `Commands/` - Command classes and interfaces.
- `CommandHandlers/` - Command handler classes.
- `Queries/` - Query classes.
- `QueryHandlers/` - Query handler classes.
- `Entities/` - Entity classes (e.g., User).
- `Repositories/` - Repository classes.
- `Interface/` - Shared interfaces for handlers.

## Example Flow
1. The user runs the application.
2. The program creates a new user named "Alice" using a command and handler.
3. The program queries for the user by ID using a query and handler.
4. The program prints the created and queried user details.

## CQRS Use Cases
- **Separation of Read and Write Workloads**: Allows independent scaling and optimization.
- **Complex Business Logic**: Isolates complex write logic from simple read logic.

## Pros
- Clear separation of concerns.
- Independent scaling for reads/writes.
- Easier to manage complex business logic.

## Cons
- More code and infrastructure.
- Increased complexity.
- Eventual consistency between models.

---
This solution is ideal for learning CQRS basics and can be extended for more advanced scenarios.
