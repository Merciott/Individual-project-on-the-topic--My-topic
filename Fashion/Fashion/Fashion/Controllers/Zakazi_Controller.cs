using Microsoft.AspNetCore.Mvc;
using Fashion.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZakazisController : ControllerBase
    {
        private readonly DruzhkoFashionContext _context;

        public ZakazisController(DruzhkoFashionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zakazi>>> GetAll()
        {
            return await _context.Zakazis.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zakazi>> GetById(int id)
        {
            var zakazi = await _context.Zakazis.FirstOrDefaultAsync(x => x.Id == id);
            if (zakazi == null)
            {
                return NotFound("Not Found");
            }
            return Ok(zakazi);
        }

        [HttpPost]
        public async Task<ActionResult<Zakazi>> Add(Zakazi zakazi)
        {
            _context.Zakazis.Add(zakazi);
            await _context.SaveChangesAsync();
            return Ok(zakazi);
        }

        [HttpPut]
        public async Task<ActionResult<Zakazi>> Update(Zakazi zakazi)
        {
            _context.Zakazis.Update(zakazi);
            await _context.SaveChangesAsync();
            return Ok(zakazi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Zakazi>> Delete(int id)
        {
            var zakazi = await _context.Zakazis.FirstOrDefaultAsync(x => x.Id == id);
            if (zakazi == null)
            {
                return NotFound("Not Found");
            }
            _context.Zakazis.Remove(zakazi);
            await _context.SaveChangesAsync();
            return Ok(zakazi);
        }
    }
}