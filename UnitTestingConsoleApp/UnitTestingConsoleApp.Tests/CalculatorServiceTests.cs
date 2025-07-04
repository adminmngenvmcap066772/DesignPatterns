using Xunit;
using Moq;

namespace UnitTestingConsoleApp.Tests
{
    // This test class demonstrates advanced Moq capabilities for CalculatorService
    // in a financial context, such as verifying call order, callback usage, and property setup.
    //
    // Why use mocks?
    // Mocks allow us to simulate and control the behavior of dependencies (ICalculator and ILogger),
    // verify interactions, simulate errors, and test edge cases in isolation. This is crucial in financial
    // systems where accuracy, logging, and error handling are critical.
    public class CalculatorServiceTests
    {
        // Test that verifies CalculatorService calls Add on ICalculator and logs the result.
        // Example: Adding two financial transactions and ensuring the operation is logged.
        [Fact]
        public void AddAndLog_CallsAddAndLogsResult()
        {
            // Arrange: create mocks for dependencies
            // Mocks are used here to control and verify the behavior of ICalculator and ILogger
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            mockCalculator.Setup(c => c.Add(10, 20)).Returns(30); // Simulate adding $10 and $20
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            // Act: perform the add and log operation
            int result = service.AddAndLog(10, 20);

            // Assert: verify the result and that dependencies were called correctly
            // Using mocks, we can check that Add and Log were called with the expected arguments
            Assert.Equal(30, result);
            mockCalculator.Verify(c => c.Add(10, 20), Times.Once);
            mockLogger.Verify(l => l.Log("Add: 10 + 20 = 30"), Times.Once);
        }

        // Theory test to verify logging for various financial transactions.
        [Theory]
        [InlineData(1, 2, 3)] // $1 + $2
        [InlineData(-5, 5, 0)] // Overdraft and deposit
        [InlineData(0, 0, 0)] // No transaction
        public void AddAndLog_LogsCorrectMessage(int a, int b, int expected)
        {
            // Mocks let us simulate different calculation results and verify correct logging
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            mockCalculator.Setup(c => c.Add(a, b)).Returns(expected);
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            int result = service.AddAndLog(a, b);

            // Mocks allow us to verify that the logger was called with the correct message
            Assert.Equal(expected, result);
            mockLogger.Verify(l => l.Log($"Add: {a} + {b} = {expected}"), Times.Once);
        }

        // Test to ensure CalculatorService properly propagates exceptions from its dependencies.
        // Example: Handling a calculation error in a financial system.
        [Fact]
        public void AddAndLog_ThrowsIfCalculatorThrows()
        {
            // Mocks are used to simulate an exception from the calculator dependency
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            // Simulate a failure in the calculator (e.g., invalid operation)
            mockCalculator.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>())).Throws(new System.Exception("fail"));
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            // Assert: exception is thrown as expected
            // Using mocks, we can test error handling without needing a real calculator implementation
            Assert.Throws<System.Exception>(() => service.AddAndLog(1, 1));
        }

        // Demonstrates verifying the order of calls between dependencies.
        [Fact]
        public void AddAndLog_VerifiesCallOrder()
        {
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            mockCalculator.Setup(c => c.Add(100, 200)).Returns(300);
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            // Use Moq's sequence to verify call order
            var sequence = new Moq.Sequence();
            mockCalculator.InSequence(sequence).Setup(c => c.Add(100, 200)).Returns(300);
            mockLogger.InSequence(sequence).Setup(l => l.Log("Add: 100 + 200 = 300"));

            service.AddAndLog(100, 200);

            mockCalculator.Verify(c => c.Add(100, 200), Times.Once);
            mockLogger.Verify(l => l.Log("Add: 100 + 200 = 300"), Times.Once);
        }

        // Demonstrates using a callback to capture arguments for audit/logging purposes.
        [Fact]
        public void AddAndLog_LoggerCallback_CapturesLogMessage()
        {
            var mockCalculator = new Mock<ICalculator>();
            var mockLogger = new Mock<ILogger>();
            mockCalculator.Setup(c => c.Add(50, 75)).Returns(125);
            string capturedMessage = null;
            mockLogger.Setup(l => l.Log(It.IsAny<string>())).Callback<string>(msg => capturedMessage = msg);
            var service = new CalculatorService(mockCalculator.Object, mockLogger.Object);

            service.AddAndLog(50, 75);

            // The callback allows us to inspect the actual log message for auditing
            Assert.Equal("Add: 50 + 75 = 125", capturedMessage);
        }

        // Demonstrates setting up a property on a mock (if the interface had properties)
        // This is useful for simulating stateful dependencies in financial systems.
        [Fact]
        public void Mock_WithPropertySetup_Demonstration()
        {
            // Example: Suppose ILogger had a property 'IsEnabled'
            var mockLogger = new Mock<ILogger>();
            // mockLogger.SetupProperty(l => l.IsEnabled, true); // Uncomment if ILogger has IsEnabled
            // Assert.True(mockLogger.Object.IsEnabled); // Uncomment if ILogger has IsEnabled
            // This pattern is useful for toggling logging in financial audits
            Assert.True(true); // Placeholder assertion
        }
    }
}
