using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
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
