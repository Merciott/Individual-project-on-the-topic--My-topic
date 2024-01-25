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

        [HttpGet] // Этот метод обрабатывает HTTP GET запросы без параметров и возвращает список всех брендов
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        [HttpGet("{id}")] // Этот метод обрабатывает HTTP GET запросы с параметром id и возвращает бренд по указанному идентификатору
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
            {
                return NotFound("Not Found");
            }
            return Ok(brand);
        }

        [HttpPost] // Этот метод обрабатывает HTTP POST запросы и добавляет новый бренд в базу данных
        public async Task<ActionResult<Brand>> Add(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpPut] // Этот метод обрабатывает HTTP PUT запросы и обновляет существующий бренд в базе данных
        public async Task<ActionResult<Brand>> Update(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpDelete("{id}")] // // Этот метод обрабатывает HTTP DELETE запросы с параметром id и удаляет бренд из базы данных по указанному идентификатору
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