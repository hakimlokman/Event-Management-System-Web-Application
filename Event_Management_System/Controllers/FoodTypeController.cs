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
    public class FoodTypeController : ControllerBase
    {
        private readonly EventDbContext _context;
        public FoodTypeController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodType>>> GetFoodType()
        {
            return await _context.FoodTypes.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodType>> GetFoodType(int id)
        {
            var Foodtype = await _context.FoodTypes.FindAsync(id);           
            return Ok(Foodtype);
        }
        // PUT: api/FoodType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodType(int id, FoodType FoodType)
        {
            if(id != FoodType.FoodTypeId)
            {
                return NotFound();
            }
            _context.Entry(FoodType).State=EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        // POST: api/FoodType
        [HttpPost]
        public async Task<ActionResult<Event>> PostFoodType(FoodType foodType)
        {
            _context.FoodTypes.Add(foodType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodType", new { id = foodType.FoodTypeId }, foodType);
        }
        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodType(int id)
        {
            var foodtype = await _context.FoodTypes.FindAsync(id);
            if (foodtype == null)
            {
                return NotFound();
            }

            _context.FoodTypes.Remove(foodtype);
            await _context.SaveChangesAsync();

            return Ok("Delete");
        }
    }
}
