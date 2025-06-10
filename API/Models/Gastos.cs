using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoPraactico_Programación3.Models
{
    public class Gastos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "La descripción debe tener entre 3 y 250 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Gastos), nameof(ValidarFechaNoFutura))]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El nombre del comercio es obligatorio.")]
        [StringLength(250, ErrorMessage = "El nombre del comercio no puede superar los 250 caracteres.")]
        [MinLength(1, ErrorMessage = "El nombre del comercio no puede estar vacío.")]
        public string NombreComercio { get; set; }

        // Validación personalizada para la fecha
        public static ValidationResult ValidarFechaNoFutura(DateTime fecha, ValidationContext context)
        {
            if (fecha > DateTime.Now)
            {
                return new ValidationResult("Error la fecha no es valida.");
            }
            return ValidationResult.Success;
        }
    }
}
