using MiApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaludoController : ControllerBase
    {
        private readonly ISaludoService _saludoService; 
        private readonly ISaludoService _saludoFormal; 
        private readonly ISaludoService _saludoInformal; 

        public SaludoController(
            MiApi.ISaludoService saludoService,
            MiApi.SaludoFormal saludoFormal,
            MiApi.SaludoInformal saludoInformal)
        {
            _saludoService = saludoService;
            _saludoFormal = saludoFormal;
            _saludoInformal = saludoInformal;
        }

        [HttpGet("{nombre}")]
        public IActionResult GtetSaludo(string nombre)
        {
            var mensaje = _saludoService.Saludar(nombre);
            return Ok(mensaje);
        }
        [HttpGet("formal/{nombre}")]
        public IActionResult GetFormal(string nombre)
        {
            var mensaje = _saludoFormal.Saludar(nombre);
            return Ok(mensaje);
        }
        [HttpGet("informal/{nombre}")]
        public IActionResult GetInformal(string nombre)
        {
            var mensaje = _saludoInformal.Saludar(nombre);
            return Ok(mensaje);
        }
    }
}