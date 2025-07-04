using Xunit;

namespace UnitTestingConsoleApp.Tests
{
    // This test class demonstrates how to use the Calculator for financial calculations.
    // Example: Calculating the sum and difference of two monetary values (e.g., account balances).
    public class CalculatorTests
    {
        // Test for adding two values, which could represent summing two account balances.
        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange: create a calculator instance
            var calculator = new Calculator();
            // Act: add two balances
            int result = calculator.Add(2000, 3000); // $2,000 + $3,000
            // Assert: verify the sum is correct
            Assert.Equal(5000, result);
        }

        // Test for subtracting two values, such as calculating remaining budget after an expense.
        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            var calculator = new Calculator();
            int result = calculator.Subtract(5000, 3000); // $5,000 - $3,000
            Assert.Equal(2000, result);
        }

        // Theory test for adding various financial values.
        [Theory]
        [InlineData(0, 0, 0)] // No funds
        [InlineData(-100, -200, -300)] // Negative balances (overdraft)
        [InlineData(1000000, 0, 1000000)] // Large balance
        [InlineData(100, -100, 0)] // Deposit and withdrawal cancel out
        public void Add_VariousInputs_ReturnsExpected(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        // Theory test for subtracting various financial values.
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-100, 100, -200)]
        [InlineData(1000, 1, 999)]
        public void Subtract_VariousInputs_ReturnsExpected(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Subtract(a, b);
            Assert.Equal(expected, result);
        }
    }
}
