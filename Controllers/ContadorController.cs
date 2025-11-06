using MiApi;
using MiApi.Services;         
using Microsoft.AspNetCore.Mvc; 
using System.Diagnostics;     
using System.Threading.Tasks; 

namespace MyApp.Namespace 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorController : ControllerBase 
    {
        private readonly MiApi.IContadorService _contador1;
        private readonly MiApi.IContadorService _contador2;
        private readonly ILlamadaService _llamadaService; 

        public ContadorController(
            MiApi.IContadorService contador1, 
            MiApi.IContadorService _contador2,
            ILlamadaService llamadaService)
        {
            _contador1 = contador1;
            this._contador2 = _contador2;
            _llamadaService = llamadaService;
        }

        [HttpGet] 
        public IActionResult Get() 
        {
            return Ok(new
            {
                PrimerValor = _contador1.ObtenerValor(),
                SegundoValor = _contador2.ObtenerValor()
            });
        }
        
        [HttpGet("Llamadas")] 
        public async Task<IActionResult> Llamadas() 
        {
            var stopwatch = Stopwatch.StartNew();

            Task<string> tareaMigue = _llamadaService.RealizarLlamadaAsync("Migue", 3000);  
            Task<string> tareaOscar = _llamadaService.RealizarLlamadaAsync("Oscar", 1000);  
            Task<string> tareaJose = _llamadaService.RealizarLlamadaAsync("Jose", 5000);    
            Task<string> tareaAlecis = _llamadaService.RealizarLlamadaAsync("Alexito", 2000); 

            string[] resultados = await Task.WhenAll(tareaMigue, tareaOscar, tareaJose, tareaAlecis);

            stopwatch.Stop();
            long tiempoTotalMs = stopwatch.ElapsedMilliseconds;

            //  Devolver un objeto JSON
            return Ok(new 
            {
                Mensaje = "Todas las llamadas se completaron en paralelo.",
                TiempoTotalEnMilisegundos = tiempoTotalMs,
                Resultados = resultados 
            });
        }
    }
}