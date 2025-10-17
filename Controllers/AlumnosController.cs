using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        static List<string> alumnos = new() { "Pedro", "Juan", "Ana" };
        [HttpGet]
        public IEnumerable<string> Get() => alumnos;
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            if (id < 0 || id >= alumnos.Count)
                return NotFound("Alumno no encontrado...");
            return alumnos[id];
        }
        [HttpPost]
        public IActionResult Add([FromBody] string nombre)
        {
            alumnos.Add(nombre);
            return Ok(new { message = "Alumno agregado." });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string nombre)
        {
            if (id < 0 || id >= alumnos.Count)
                return NotFound("Alumno no encontrado...");
            alumnos[id] = nombre;
            return Ok(new { message = "Alumno actualizado." });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= alumnos.Count){}
                return NotFound("Alumno no encontrado...");
            alumnos.RemoveAt(id);
            return Ok(new { message = "Alumno eliminado." });
        }
    }
}
