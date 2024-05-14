using Event_Management.Models;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FoodController : ControllerBase
    {
        private readonly EventDbContext _context;
        public FoodController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFood()
        {
            return await _context.Foods.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            var GetFood = await _context.Foods.FindAsync(id);

            if (GetFood == null)
            {
                return NotFound();
            }
            return GetFood;
        }
        // PUT: api/Food/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food Food)
        {
            if (id != Food.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(Food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/Food
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFood", new { id = food.FoodId }, food);
        }
        // DELETE: api/Food/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var Deletefood = await _context.Foods.FindAsync(id);
            if (Deletefood == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(Deletefood);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool FoodExist(int id)
        {
            return _context.Foods.Any(f => f.FoodId == id);
        }
    }
}
