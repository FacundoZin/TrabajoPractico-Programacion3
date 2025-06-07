using TrabajoPraactico_Programación3.DTO;
using TrabajoPraactico_Programación3.Models;

namespace TrabajoPraactico_Programación3.Mappers
{
    public static class GastosMapper
    {
        public static Gastos ToGasto (this CreateGastoDto stockcreado)
        {
            return new Gastos
            {
                Monto = stockcreado.Monto,
                Desccripcion = stockcreado.Descripcion,
                Fecha = stockcreado.Fecha,
                NombreComercio = stockcreado.NombreComercio,
            };
        }

        public static CreatedGasto ToCreatedGasto(this Gastos gasto)
        {
            return new CreatedGasto
            {
                Id = gasto.Id,
                Monto = gasto.Monto,
                Desccripcion = gasto.Desccripcion,
                Fecha = gasto.Fecha,
                NombreComercio = gasto.NombreComercio,
            };
        }

        public static GastoDto ToGastoDto (this Gastos gasto)
        {
            return new GastoDto
            {
                Monto = gasto.Monto,
                Desccripcion = gasto.Desccripcion,
                Fecha = gasto.Fecha,
                NombreComercio = gasto.NombreComercio
            };
        }
    }
}
