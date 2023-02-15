using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("saludos")]
    [ApiController]
    public class SaludosController : ControllerBase
    {
        [HttpGet("{nombre}")]
        public ActionResult<string> ObtenerSaludo(string nombre)
        {
            return $"Hola, {nombre}";
        }

        [HttpGet("delay/{nombre}")]
        public async Task<ActionResult<string>> ObtenerSaludoConDelay(string nombre)
        {
            var esperar = RandomGen.NextDouble() * 10 + 1;
            await Task.Delay((int)esperar * 1000);
            return $"Hola, {nombre}";
        }
    }
}
