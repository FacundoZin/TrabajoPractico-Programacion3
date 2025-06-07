using Microsoft.EntityFrameworkCore;
using TrabajoPraactico_Programación3.Data;
using TrabajoPraactico_Programación3.DTO;
using TrabajoPraactico_Programación3.Interfaces;
using TrabajoPraactico_Programación3.Models;

namespace TrabajoPraactico_Programación3.Repository
{
    public class GastosRepository : IGastosRepository
    {
        private readonly ApplicationDbContext _Context;
        public GastosRepository(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<Gastos> Add(Gastos gasto)
        {

            _Context.Gastos.Add(gasto);
            await _Context.SaveChangesAsync();
            return gasto;
        }

        public async Task<List<Gastos>> GetAll()
        {
            var ListaDeGastos = await _Context.Gastos.ToListAsync();
            return ListaDeGastos;
        }
    }
}
