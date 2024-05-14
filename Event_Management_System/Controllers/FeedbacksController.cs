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
    public class FeedbacksController : ControllerBase
    {
        private readonly EventDbContext _context;
        public FeedbacksController(EventDbContext context)
        {    
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            var feedback = await _context.Feedbacks.ToListAsync();
            return Ok(feedback);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok( feedback);
        }
        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedback(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return Ok(feedback);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Feedback>> UpdateFeedback(int id, Feedback feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return BadRequest();
            }
            _context.Entry(feedback).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(feedback);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return Ok("Data Deleted");
        }
    }
}

