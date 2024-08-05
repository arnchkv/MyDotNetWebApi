using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _context.MyModels.ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _context.MyModels.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MyModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            _context.MyModels.Add(model);
            _context.SaveChanges();

            return Ok(new { message = "Item created", item = model });
        }
    }
}
