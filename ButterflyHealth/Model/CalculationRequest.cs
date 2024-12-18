using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ButterflyHealth.Model
{
    public class CalculationRequest
    {
        [Required(ErrorMessage = "First number is invalid")]
        public double FirstNumber { get; set; }

        [Required(ErrorMessage = "Second number is invalid")]
        public double SecondNumber { get; set; }

    }
}
