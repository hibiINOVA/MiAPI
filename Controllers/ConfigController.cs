using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConfigController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var urlUsuarios = _config["ExternalApis:Usuarios"];
            var urlPosts = _config["ExternalApis:Posts"];

            return Ok(new { urlUsuarios, urlPosts });
        }
    }
}