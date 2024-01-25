using Microsoft.AspNetCore.Mvc;
using Fashion.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolzovatelsController : ControllerBase
    {
        private readonly DruzhkoFashionContext _context;

        public PolzovatelsController(DruzhkoFashionContext context)
        {
            _context = context;
        }

        [HttpGet] // Этот метод обрабатывает HTTP GET запросы без параметров и возвращает список всех пользователей
        public async Task<ActionResult<IEnumerable<Polzovatel>>> GetAll()
        {
            return await _context.Polzovatels.ToListAsync();
        }

        [HttpGet("{id}")] // Этот метод обрабатывает HTTP GET запросы с параметром id и возвращает пользователя по указанному идентификатору
        public async Task<ActionResult<Polzovatel>> GetById(int id)
        {
            var polzovatel = await _context.Polzovatels.FirstOrDefaultAsync(x => x.Id == id);
            if (polzovatel == null)
            {
                return NotFound("Not Found");
            }
            return Ok(polzovatel);
        }

        [HttpPost] // Этот метод обрабатывает HTTP POST запросы и добавляет нового пользователя в базу данных
        public async Task<ActionResult<Polzovatel>> Add(Polzovatel polzovatel)
        {
            _context.Polzovatels.Add(polzovatel);
            await _context.SaveChangesAsync();
            return Ok(polzovatel);
        }

        [HttpPut] // Этот метод обрабатывает HTTP PUT запросы и обновляет существующего пользователя в базе данных
        public async Task<ActionResult<Polzovatel>> Update(Polzovatel polzovatel)
        {
            _context.Polzovatels.Update(polzovatel);
            await _context.SaveChangesAsync();
            return Ok(polzovatel);
        }

        [HttpDelete("{id}")] // Этот метод обрабатывает HTTP DELETE запросы с параметром id и удаляет пользователя из базы данных по указанному идентификатору
        public async Task<ActionResult<Polzovatel>> Delete(int id)
        {
            var polzovatel = await _context.Polzovatels.FirstOrDefaultAsync(x => x.Id == id);
            if (polzovatel == null)
            {
                return NotFound("Not Found");
            }
            _context.Polzovatels.Remove(polzovatel);
            await _context.SaveChangesAsync();
            return Ok(polzovatel);
        }
    }
}