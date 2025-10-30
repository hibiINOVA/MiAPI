using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpFactoryController : ControllerBase
    {
        private readonly HttpClient _HttpClient;
        public HttpFactoryController(IHttpClientFactory httpClientFactory)
        {
            _HttpClient = httpClientFactory.CreateClient("jsonplaceholder");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _HttpClient.GetAsync("users");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error al obtener los datos...");
            }
            var contenido = await response.Content.ReadAsStringAsync();
            return Ok(contenido);
        }
    }
}
