using Microsoft.AspNetCore.Mvc;
using TrabajoPraactico_Programación3.DTO;
using TrabajoPraactico_Programación3.Interfaces;
using TrabajoPraactico_Programación3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajoPraactico_Programación3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IGastosServices _GastoService;

        public GastosController(IGastosServices gastosServices)
        {
            _GastoService = gastosServices;
        }

        // POST api/<GastosController>
        [HttpPost]
        public async Task<IActionResult> CargarGasto([FromBody] CreateGastoDto createGastoDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var GastoCargado = await _GastoService.CargarGasto(createGastoDto);

            return CreatedAtAction(nameof(Gastos), new { id = GastoCargado.Id }, GastoCargado);

        }

        [HttpGet]
        public async Task<IActionResult> ObtenerGastos()
        {
            var ListaGastos = await _GastoService.ObtenerTodosLosGastos();

            return Ok(ListaGastos);
        }


    }
}
