using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoPraactico_Programación3.Models;

namespace TrabajoPraactico_Programación3.DTO
{
    public class GastoDto
    {
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreComercio { get; set; }
    }
}
