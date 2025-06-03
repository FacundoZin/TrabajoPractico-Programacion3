using Microsoft.AspNetCore.Mvc;
using TrabajoPraactico_Programación3.DTO;
using TrabajoPraactico_Programación3.Interfaces;

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

            _GastoService.

            return Ok();
        }


    }
}
