using System.ComponentModel.DataAnnotations;

namespace Laba1_TP.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Введите значение первого операнда!")]
        public ulong Operand1 { get; set; }

        [Range(1, 100, ErrorMessage = "Второй операнд должен быть в диапазоне от 1 до 100!")]
        public double Operand2 { get; set; }

        public string Operation { get; set; } = "+";
        public double Result { get; set; }
    }
} 