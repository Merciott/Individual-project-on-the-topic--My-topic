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

        [HttpGet] // Этот метод обрабатывает HTTP GET запросы без параметров и возвращает список всех заказов
        public async Task<ActionResult<IEnumerable<Zakazi>>> GetAll()
        {
            return await _context.Zakazis.ToListAsync();
        }

        [HttpGet("{id}")] // Этот метод обрабатывает HTTP GET запросы с параметром id и возвращает заказ по указанному идентификатору
        public async Task<ActionResult<Zakazi>> GetById(int id)
        {
            var zakazi = await _context.Zakazis.FirstOrDefaultAsync(x => x.Id == id);
            if (zakazi == null)
            {
                return NotFound("Not Found");
            }
            return Ok(zakazi);
        }

        [HttpPost] // Этот метод обрабатывает HTTP POST запросы и добавляет новый заказ в базу данных
        public async Task<ActionResult<Zakazi>> Add(Zakazi zakazi)
        {
            _context.Zakazis.Add(zakazi);
            await _context.SaveChangesAsync();
            return Ok(zakazi);
        }

        [HttpPut] // Этот метод обрабатывает HTTP PUT запросы и обновляет существующий заказ в базе данных
        public async Task<ActionResult<Zakazi>> Update(Zakazi zakazi)
        {
            _context.Zakazis.Update(zakazi);
            await _context.SaveChangesAsync();
            return Ok(zakazi);
        }

        [HttpDelete("{id}")] // Этот метод обрабатывает HTTP DELETE запросы с параметром id и удаляет заказ из базы данных по указанному идентификатору
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