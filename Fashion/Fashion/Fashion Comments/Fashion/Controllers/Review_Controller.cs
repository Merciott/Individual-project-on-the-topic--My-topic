using Microsoft.AspNetCore.Mvc;
using Fashion.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly DruzhkoFashionContext _context;

        public ReviewsController(DruzhkoFashionContext context)
        {
            _context = context;
        }

        [HttpGet] // Этот метод обрабатывает HTTP GET запросы без параметров и возвращает список всех отзывов
        public async Task<ActionResult<IEnumerable<Review>>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }

        [HttpGet("{id}")] // Этот метод обрабатывает HTTP GET запросы с параметром id и возвращает отзыв по указанному идентификатору
        public async Task<ActionResult<Review>> GetById(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if (review == null)
            {
                return NotFound("Not Found");
            }
            return Ok(review);
        }

        [HttpPost] // Этот метод обрабатывает HTTP POST запросы и добавляет новый отзыв в базу данных
        public async Task<ActionResult<Review>> Add(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return Ok(review);
        }

        [HttpPut] // Этот метод обрабатывает HTTP PUT запросы и обновляет существующий отзыв в базе данных
        public async Task<ActionResult<Review>> Update(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return Ok(review);
        }

        [HttpDelete("{id}")] // Этот метод обрабатывает HTTP DELETE запросы с параметром id и удаляет отзыв из базы данных по указанному идентификатору
        public async Task<ActionResult<Review>> Delete(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if (review == null)
            {
                return NotFound("Not Found");
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return Ok(review);
        }
    }
}