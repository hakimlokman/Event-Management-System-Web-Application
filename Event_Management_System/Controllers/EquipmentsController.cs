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
    public class EquipmentsController : ControllerBase
    {
        private readonly EventDbContext _context;
        public EquipmentsController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipments()
        {
            var equipment = await _context.Equipment.ToListAsync();
            return Ok(equipment);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if(equipment == null)
            {
                return NotFound();
            }
            return equipment;
        }
        [HttpPost]
        public async Task<ActionResult<Equipment>> AddEquipment(Equipment equipment)
        {
            await _context.Equipment.AddAsync(equipment);
            await _context.SaveChangesAsync();
            return Ok(equipment);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Equipment>> UpdateEquipment(int id, Equipment equipment)
        {
            if (id != equipment.EquipmentId)
            {
                return BadRequest();
            }
            _context.Entry(equipment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(equipment);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equipment>> DeleteEquipment(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
            return Ok("Data Deleted");
        }
    }
}
