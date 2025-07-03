using Xunit;
using Moq;

namespace UnitTestingConsoleApp.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void AddAndLog_CallsAddAndLogsResult()
        {
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            mockCalculator.Setup(c => c.Add(10, 20)).Returns(30);
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            int result = service.AddAndLog(10, 20);

            Assert.Equal(30, result);
            mockCalculator.Verify(c => c.Add(10, 20), Times.Once);
            mockLogger.Verify(l => l.Log("Add: 10 + 20 = 30"), Times.Once);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-5, 5, 0)]
        [InlineData(0, 0, 0)]
        public void AddAndLog_LogsCorrectMessage(int a, int b, int expected)
        {
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            mockCalculator.Setup(c => c.Add(a, b)).Returns(expected);
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            int result = service.AddAndLog(a, b);

            Assert.Equal(expected, result);
            mockLogger.Verify(l => l.Log($"Add: {a} + {b} = {expected}"), Times.Once);
        }

        [Fact]
        public void AddAndLog_ThrowsIfCalculatorThrows()
        {
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            mockCalculator.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>())).Throws(new System.Exception("fail"));
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            Assert.Throws<System.Exception>(() => service.AddAndLog(1, 1));
        }
    }
}
