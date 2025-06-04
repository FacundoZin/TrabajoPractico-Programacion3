using TrabajoPraactico_Programación3.DTO;
using TrabajoPraactico_Programación3.Interfaces;
using TrabajoPraactico_Programación3.Mappers;

namespace TrabajoPraactico_Programación3.Services
{
    public class GastosService : IGastosServices
    {
        private readonly IGastosRepository _repository;
        public GastosService(IGastosRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreatedGasto> CargarGasto(CreateGastoDto dto)
        {
            var gasto = dto.ToGasto();
            await _repository.Add(gasto);
            return gasto.ToCreatedGasto();
        }

        public async Task<List<GastoDto>> ObtenerTodosLosGastos()
        {
            var Gastos = await _repository.GetAll();

            var ListaGastos = Gastos.Select(G => G.ToGastoDto()).ToList();

            return ListaGastos;
        }


    }
}
