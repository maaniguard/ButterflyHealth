using ButterflyHealth.Model;

namespace ButterflyHealth.Services
{
    public class CalculatorService : ICalculatorService
    {
        // sum of 2 numbers 
        public double Add(double firstNumber, double secondNumber) => firstNumber + secondNumber;
        // Subtract of 2 numbers 
        public double Subtract(double firstNumber, double secondNumber) => firstNumber - secondNumber;
        // Multiplying 2 numbers 
        public double Multiply(double firstNumber, double secondNumber) => firstNumber * secondNumber;
        // Dividing 2 numbers 
        public double Divide(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0) throw new InvalidOperationException("Division by zero is not allowed.");
            return firstNumber / secondNumber;
        }
    }
}
