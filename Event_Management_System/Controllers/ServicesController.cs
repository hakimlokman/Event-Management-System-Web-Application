using Event_Management.Models;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly EventDbContext _context;
        public ServicesController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> GetServices()
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Services>> GetServices(int id)
        {
            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return services;
        }
        [HttpPost]
        public async Task<ActionResult<Services>> AddServices(Services services)
        {
            await _context.Services.AddAsync(services);
            await _context.SaveChangesAsync();
            return Ok(services);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Services>> UpdateServices(int id, Services services)
        {
            if (id != services.ServicesId)
            {
                return BadRequest();
            }
            _context.Entry(services).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(services);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Services>> DeleteServices(int id)
        {
            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            _context.Services.Remove(services);
            await _context.SaveChangesAsync();
            return Ok("Data Deleted Successfully...!!!");
        }
    }
}
