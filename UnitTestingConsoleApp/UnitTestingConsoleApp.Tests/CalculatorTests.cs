using Xunit;

namespace UnitTestingConsoleApp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            var calculator = new Calculator();
            int result = calculator.Add(2, 3);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            var calculator = new Calculator();
            int result = calculator.Subtract(5, 3);
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -2)]
        [InlineData(int.MaxValue, 0, int.MaxValue)]
        [InlineData(100, -100, 0)]
        public void Add_VariousInputs_ReturnsExpected(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-1, 1, -2)]
        [InlineData(100, 1, 99)]
        public void Subtract_VariousInputs_ReturnsExpected(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Subtract(a, b);
            Assert.Equal(expected, result);
        }
    }
}
