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
    public class WorkersController : ControllerBase
    {
        private readonly EventDbContext _context;
        public WorkersController(EventDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorker()
        {
            return await _context.Workers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            return Ok(worker);
        }
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            return Ok(worker);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutWorker(int id, Worker worker)
        {
            _context.Entry(worker).State = EntityState.Modified;
            return Ok(worker);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            var delworker = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(delworker);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
