using Microsoft.AspNetCore.Mvc;
using Fashion.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly DruzhkoFashionContext _context;

        public BrandsController(DruzhkoFashionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
            {
                return NotFound("Not Found");
            }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> Add(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpPut]
        public async Task<ActionResult<Brand>> Update(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> Delete(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
            {
                return NotFound("Not Found");
            }
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return Ok(brand);
        }
    }
}