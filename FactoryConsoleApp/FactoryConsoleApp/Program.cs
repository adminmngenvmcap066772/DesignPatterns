// See https://aka.ms/new-console-template for more information
using FactoryConsoleApp.FinancialProducts;

Console.WriteLine("Hello, World!");

// This example demonstrates the Factory Pattern in a financial context.
// We will create a factory that produces different types of financial products.

// Create a Loan product using the factory
var loan = FinancialProductFactory.CreateProduct("Loan");
loan.Describe();

// Create a SavingsAccount product using the factory
var savings = FinancialProductFactory.CreateProduct("SavingsAccount");
savings.Describe();
