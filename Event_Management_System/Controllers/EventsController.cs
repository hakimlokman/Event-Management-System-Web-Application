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
    public class EventsController : ControllerBase
    {
        private readonly EventDbContext _context;
        public EventsController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var events=await _context.Events.FindAsync(id);
            return Ok(events);  
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent( Event events)
        {
            _context.Events.Add(events);
            await _context.SaveChangesAsync();
            return Ok(events);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEvent(int id,Event events)
        {
            _context.Entry(events).State = EntityState.Modified;
            return Ok(events);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var delEvent = await _context.Events.FindAsync(id);
            _context.Events.Remove(delEvent);
            await _context.SaveChangesAsync();
            return Ok("Delete");
        }
    }
}
