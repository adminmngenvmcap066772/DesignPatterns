using System;
using Xunit;

namespace UnitTestingConsoleApp.Tests
{
    // This class contains unit tests for financial calculations.
    // The example demonstrates how to calculate compound interest, a common financial scenario.
    public class UnitTest1
    {
        // This method calculates the compound interest for a given principal, rate, and time period.
        // Formula: A = P * (1 + r/n)^(n*t)
        // Where:
        //   P = principal amount
        //   r = annual interest rate (decimal)
        //   n = number of times interest applied per time period
        //   t = number of time periods elapsed
        public double CalculateCompoundInterest(double principal, double rate, int timesCompounded, int years)
        {
            // Calculate the compound interest using the formula
            return principal * Math.Pow(1 + rate / timesCompounded, timesCompounded * years);
        }

        [Fact]
        public void CalculateCompoundInterest_ShouldReturnCorrectAmount()
        {
            // Arrange: Set up the principal, rate, times compounded, and years
            double principal = 1000; // $1,000 initial investment
            double rate = 0.05;      // 5% annual interest rate
            int timesCompounded = 4; // Compounded quarterly
            int years = 3;           // For 3 years

            // Act: Calculate the final amount
            double result = CalculateCompoundInterest(principal, rate, timesCompounded, years);

            // Assert: The expected value is calculated manually or using a financial calculator
            double expected = 1000 * Math.Pow(1 + 0.05 / 4, 4 * 3);
            Assert.Equal(expected, result, 2); // Allowing a small tolerance for floating point precision
        }
    }
}
