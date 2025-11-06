using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Es buena idea agregar estos 'usings' para HttpClient y Tasks
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpFactoryController : ControllerBase
    {
        private readonly HttpClient _httclient;
        public HttpFactoryController(IHttpClientFactory httpClientFactory)
        {
            _httclient = httpClientFactory.CreateClient("jsonplaceholder");
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _httclient.GetAsync("users");
            
            // 1. Primero manejamos el caso de ERROR
            if (!response.IsSuccessStatusCode)
            {
                // Si la respuesta NO es exitosa, retornamos el error y salimos.
                return StatusCode((int)response.StatusCode, "Error al obtener datos.");
            }

            // 2. Si llegamos aquí, SÍ fue exitosa.
            // Movemos la lógica de éxito FUERA del 'if'.
            var contenido = await response.Content.ReadAsStringAsync();
            return Ok(contenido);  

        } // <-- 3. Faltaba esta llave para cerrar Get()
    } // <-- 4. Faltaba esta llave para cerrar la clase
}