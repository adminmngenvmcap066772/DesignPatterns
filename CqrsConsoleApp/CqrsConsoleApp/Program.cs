// See https://aka.ms/new-console-template for more information

using CqrsConsoleApp.Repositories;
using CqrsConsoleApp.CommandHandlers;
using CqrsConsoleApp.Commands;
using CqrsConsoleApp.QueryHandlers;
using CqrsConsoleApp.Queries;

// Entry point for the CQRS demo application
Console.WriteLine("Hello, World!");

var repository = new UserRepository();

// Create a new user using the command handler
var createHandler = new CreateUserCommandHandler(repository);
var user = createHandler.Handle(new CreateUserCommand("Alice"));
Console.WriteLine($"Created user: {user.Id} - {user.Name}");

// Query the user by ID using the query handler
var queryHandler = new GetUserQueryHandler(repository);
var queriedUser = queryHandler.Handle(new GetUserQuery(user.Id));
Console.WriteLine(queriedUser != null
    ? $"Queried user: {queriedUser.Id} - {queriedUser.Name}"
    : "User not found");
