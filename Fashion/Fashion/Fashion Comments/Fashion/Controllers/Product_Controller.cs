using Microsoft.AspNetCore.Mvc;
using Fashion.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DruzhkoFashionContext _context;

        public ProductsController(DruzhkoFashionContext context)
        {
            _context = context;
        }

        [HttpGet] // Этот метод обрабатывает HTTP GET запросы без параметров и возвращает список всех продуктов
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")] // Этот метод обрабатывает HTTP GET запросы с параметром id и возвращает продукт по указанному идентификатору
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound("Not Found");
            }
            return Ok(product);
        }

        [HttpPost] // Этот метод обрабатывает HTTP POST запросы и добавляет новый продукт в базу данных
        public async Task<ActionResult<Product>> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut] // Этот метод обрабатывает HTTP PUT запросы и обновляет существующий продукт в базе данных
        public async Task<ActionResult<Product>> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")] // Этот метод обрабатывает HTTP DELETE запросы с параметром id и удаляет продукт из базы данных по указанному идентификатору
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound("Not Found");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }
}