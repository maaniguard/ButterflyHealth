using Moq;
using NUnit.Framework;

namespace Butterfly.Health.Test
{
    [TestFixture]
    public class CalculatorControllerTests
    {
        private Mock<ICalculatorService> _mockCalculatorService;
        private Mock<ILogger<CalculatorController>> _mockLogger;
        private CalculatorController _controller;

        [SetUp]
        public void Setup()
        {
            _mockCalculatorService = new Mock<ICalculatorService>();
            _mockLogger = new Mock<ILogger<CalculatorController>>();
            _controller = new CalculatorController(_mockCalculatorService.Object, _mockLogger.Object);
        }

        [Test]
        public void Add_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 3 };
            _mockCalculatorService.Setup(service => service.Add(It.IsAny<double>(), It.IsAny<double>())).Returns(8);

            // Act
            var result = _controller.Add(request) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(8, ((dynamic)result.Value).Result);
        }

        [Test]
        public void Add_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("FirstNumber", "Required");

            // Act
            var result = _controller.Add(new CalculationRequest()) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        // Similar tests for Subtract, Multiply, and Divide methods

        [Test]
        public void Divide_DivideByZero_ReturnsBadRequest()
        {
            // Arrange
            var request = new CalculationRequest { FirstNumber = 5, SecondNumber = 0 };
            _mockCalculatorService.Setup(service => service.Divide(It.IsAny<double>(), It.IsAny<double>())).Throws(new InvalidOperationException("Division by zero is not allowed."));

            // Act
            var result = _controller.Divide(request) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Division by zero is not allowed.", result.Value);

        }
