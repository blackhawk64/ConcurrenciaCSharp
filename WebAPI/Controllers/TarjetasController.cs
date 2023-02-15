using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarjetasController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> ProcesarTarjeta([FromBody] string tarjeta)
        {
            var valorAleatorio = RandomGen.NextDouble();
            var aprobada = valorAleatorio > 0.1;

            await Task.Delay(1000);
            Console.WriteLine($"Tarjeta procesada: {tarjeta}");

            return Ok(new
            {
                Tarjeta = tarjeta,
                Aprobada = aprobada
            });
        }
    }
}
