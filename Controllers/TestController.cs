using ApiPruebaTec.Data;
using ApiPruebaTec.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTec.Controllers
{
    //[Authorize]
    //[EnableCors("PermitirDominiosEspecificos")]
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TestController : Controller
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Este es un mensaje desde el endpoint GET.");
        }
        // POST: api/personas
        [HttpPost]
        public IActionResult PostPersona([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Personas.Add(persona);
            _context.SaveChanges();

            return CreatedAtAction(nameof(PostPersona), new { id = persona.Id }, persona);
        }
        // GET: api/personas/{id}
        [HttpGet("{id}")]
        public IActionResult GetPersona(int id)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.Id == id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }
    }
}
