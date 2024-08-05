using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System.Linq;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassroomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var classrooms = _context.Classrooms.ToList();
            return Ok(classrooms);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Classroom classroom)
        {
            if (classroom == null)
            {
                return BadRequest();
            }

            _context.Classrooms.Add(classroom);
            _context.SaveChanges();

            return Ok(new { message = "Classroom created", classroom = classroom });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Classroom classroom)
        {
            var existingClassroom = _context.Classrooms.Find(id);
            if (existingClassroom == null)
            {
                return NotFound();
            }

            existingClassroom.Name = classroom.Name;
            existingClassroom.Location = classroom.Location;

            _context.Classrooms.Update(existingClassroom);
            _context.SaveChanges();

            return Ok(new { message = "Classroom updated", classroom = existingClassroom });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();

            return Ok(new { message = "Classroom deleted" });
        }
    }
}
