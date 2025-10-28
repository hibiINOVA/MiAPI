namespace MiApi;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ContadorController : ControllerBase
{
    private readonly IContadorService _contador1;
    private readonly IContadorService _contador2;

    public ContadorController(IContadorService contador1, IContadorService contador2)
    {
        _contador1 = contador1;
        _contador2 = contador2;
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
    [HttpGet("llamadas")] 
public async Task<IActionResult> Llamadas()
{
    ILlamada llamadaService = new LlamadaService();

    var llamadas = new List<Task<string>>
    {
        llamadaService.Llamada("Llamada 1", 2000),
        llamadaService.Llamada("Llamada 2", 1000),
        llamadaService.Llamada("Llamada 3", 3000)
    };

    var resultados = await Task.WhenAll(llamadas);

    return Ok(new { llamadas = resultados });
}

}

