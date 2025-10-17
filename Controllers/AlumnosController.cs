using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        static List<Alumno> alumnos = new()
        {
            new Alumno { Nombre = "Pedro", Edad = 20 },
            new Alumno { Nombre = "Juan", Edad = 22 },
            new Alumno { Nombre = "Ana", Edad = 21 },
            new Alumno { Nombre = "Maria", Edad = 23 },
            new Alumno { Nombre = "Luis", Edad = 24 },
            new Alumno { Nombre = "Sofia", Edad = 25 }
        };
        [HttpGet]
        public IEnumerable<Alumno> Get() => alumnos;
        [HttpGet("{id}")]
        public ActionResult<Alumno> GetById(int id)
        {
            if (id < 0 || id >= alumnos.Count)
                return NotFound("Alumno no encontrado...");
            return alumnos[id];
        }
        [HttpPost]
        public IActionResult Add([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok(new { message = "Alumno " + alumno.Nombre + " agregado.", total = alumnos.Count });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Alumno alumno)
        {
            if (id < 0 || id >= alumnos.Count)
                return NotFound("Alumno no encontrado...");
            alumnos[id] = alumno;
            return Ok(new { message = "Alumno actualizado por " + alumno.Nombre + "." });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= alumnos.Count)
                return NotFound("Alumno no encontrado...");
            alumnos.RemoveAt(id);
            return Ok(new { message = "Alumno eliminado." });
        }


        [HttpGet("info")]
        //public IActionResult Info([FromHeader(Name = "Amor")] string agente)
        public IActionResult Info([FromHeader(Name = "User-Agent")] string agente)
        {
            if (string.IsNullOrEmpty(agente))
            {
                return BadRequest("No encontrado...");
            }
            return Ok($"Tu navegador es: {agente}");
        }
    }
}
