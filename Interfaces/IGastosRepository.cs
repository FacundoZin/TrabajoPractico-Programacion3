using TrabajoPraactico_Programación3.Models;

namespace TrabajoPraactico_Programación3.Interfaces
{
    public interface IGastosRepository
    {
        Task<Gastos> Add(Gastos gasto);
        Task<List<Gastos>> GetAll ();

    }
}
