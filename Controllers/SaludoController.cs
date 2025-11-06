using MiApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaludoController : ControllerBase
    {
        private readonly ISaludoService _saludoService;
        private readonly ISaludoService _saludoFormal;
        private readonly ISaludoService _saludoInformal;

        // Constructor con inyección de dependencias
        public SaludoController(
            ISaludoService saludoService,
            [FromKeyedServices("Formal")] ISaludoService formal,
            [FromKeyedServices("Informal")] ISaludoService informal)
        {
            _saludoService = saludoService;
            _saludoFormal = formal;
            _saludoInformal = informal;
        }

        [HttpGet("{nombre}")]
        public IActionResult GetSaludo(string nombre)
        {
            var mensaje = _saludoService.Saludar(nombre);
            return Ok(mensaje);
        }

        [HttpGet("formal/{nombre}")]
        public IActionResult GetSaludoFormal(string nombre)
        {
            var mensaje = _saludoFormal.Saludar(nombre);
            return Ok(mensaje);
        }

        [HttpGet("informal/{nombre}")]
        public IActionResult GetSaludoInformal(string nombre)
        {
            var mensaje = _saludoInformal.Saludar(nombre);
            return Ok(mensaje);
        }
    }
}
