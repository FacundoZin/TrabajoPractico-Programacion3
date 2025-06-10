namespace TrabajoPraactico_Programación3.DTO
{
    public class CreatedGasto
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreComercio { get; set; }
    }
}
