using TrabajoPraactico_Programación3.DTO;

namespace TrabajoPraactico_Programación3.Interfaces
{
    public interface IGastosServices 
    {
        Task<CreatedGasto> CargarGasto(CreateGastoDto dto);
        Task<List<GastoDto>> ObtenerTodosLosGastos();
    }
}
