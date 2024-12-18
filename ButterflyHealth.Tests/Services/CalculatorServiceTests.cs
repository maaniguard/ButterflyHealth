using ButterflyHealth.Services;

namespace ButterflyHealth.Tests.Services
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorServiceTests()
        {
            _calculatorService = new CalculatorService(); // Instantiate the service being tested.
        }

        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            double firstNumber = 15;
            double secondNumber = 3;

            var result = _calculatorService.Add(firstNumber, secondNumber);

            // Assert
            Assert.Equal(18, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectSubtract()
        {
            // Arrange
            double firstNumber = 14;
            double secondNumber = 4;

            // perform
            var result = _calculatorService.Subtract(firstNumber, secondNumber);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Multiply_ShouldReturnCorrectMultiply()
        {
            // Arrange
            double firstNumber = 10;
            double secondNumber = 6;

            var result = _calculatorService.Multiply(firstNumber, secondNumber);

            // Assert
            Assert.Equal(60, result);
        }

        [Fact]
        public void Divide_ShouldReturnCorrectDivision()
        {
            // Arrange
            double firstNumber = 12;
            double secondNumber = 4;

            var result = _calculatorService.Divide(firstNumber, secondNumber);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            // Arrange
            double firstNumber = 10;
            double secondNumber = 0;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _calculatorService.Divide(firstNumber, secondNumber));
        }
    }
}
