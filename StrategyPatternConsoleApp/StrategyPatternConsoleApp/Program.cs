// This program demonstrates the Strategy Pattern in a finance scenario: calculating interest using different strategies.
// The main entry point will show how to use the InterestCalculator with different interest calculation strategies.

using StrategyPatternConsoleApp;
using StrategyPatternConsoleApp.Strategies;

// Create an interest calculator with the simple interest strategy
var simpleCalculator = new InterestCalculator(new SimpleInterestStrategy());
Console.WriteLine($"Simple Interest: {simpleCalculator.Calculate(1000, 0.05, 2):F2}");

// Create an interest calculator with the compound interest strategy
var compoundCalculator = new InterestCalculator(new CompoundInterestStrategy());
Console.WriteLine($"Compound Interest: {compoundCalculator.Calculate(1000, 0.05, 2):F2}");
