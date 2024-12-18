using ButterflyHealth.Model;
using ButterflyHealth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyHealth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<CalculatorController> _logger;
        // Injecting the calculatorservice and logger
        public CalculatorController(ICalculatorService calculatorService, ILogger<CalculatorController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CalculationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // calculating using calc service Add operation
                var result = _calculatorService.Add(request.FirstNumber, request.SecondNumber);

                _logger.LogInformation($"Addition: {request.FirstNumber} + {request.SecondNumber} = {result}");
                return Ok(new { Result = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during addition operaion");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] CalculationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // calculating using calc service subtract operation
                var result = _calculatorService.Subtract(request.FirstNumber, request.SecondNumber);
                _logger.LogInformation($"Subtraction: {request.FirstNumber} - {request.SecondNumber} = {result}");
                return Ok(new { Result = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during subtraction operation");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("multiply")]
        public IActionResult Multiply([FromBody] CalculationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // calculating using calc service multiply operation
                var result = _calculatorService.Multiply(request.FirstNumber, request.SecondNumber);
                _logger.LogInformation($"Multiplication: {request.FirstNumber} * {request.SecondNumber} = {result}");
                return Ok(new { Result = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during multiplying operation");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] CalculationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // calculating using calc service divide operation
                var result = _calculatorService.Divide(request.FirstNumber, request.SecondNumber);
                _logger.LogInformation($"Division: {request.FirstNumber} / {request.SecondNumber} = {result}");
                return Ok(new { Result = result });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during dividing operation");
                return BadRequest(ex.Message);
            }
        }
    }
}
