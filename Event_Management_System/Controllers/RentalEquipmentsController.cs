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
    public class RentalEquipmentsController : ControllerBase
    {
        private readonly EventDbContext _context;
        public RentalEquipmentsController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalEquipment>>> GetRentalEquipments()
        {
            var rentalEquipment = await _context.RentalEquipment.ToListAsync();
            return Ok(rentalEquipment);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalEquipment>> GetRentalEquipment(int id)
        {
            var rentalEquipment = await _context.RentalEquipment.FindAsync(id);
            if (rentalEquipment == null)
            {
                return NotFound();
            }
            return rentalEquipment;
        }
        [HttpPost]
        public async Task<ActionResult<RentalEquipment>> AddRentalEquipment(RentalEquipment rentalEquipment)
        {
            await _context.RentalEquipment.AddAsync(rentalEquipment);
            await _context.SaveChangesAsync();
            return Ok(rentalEquipment);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RentalEquipment>> UpdateRentalEquipment(int id, RentalEquipment rentalEquipment)
        {
            if (id != rentalEquipment.RentalEquipmentId)
            {
                return BadRequest();
            }
            _context.Entry(rentalEquipment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(rentalEquipment);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentalEquipment>> DeleteRentalEquipment(int id)
        {
            var rentalEquipment = await _context.RentalEquipment.FindAsync(id);
            if (rentalEquipment == null)
            {
                return NotFound();
            }
            _context.RentalEquipment.Remove(rentalEquipment);
            await _context.SaveChangesAsync();
            return Ok("Data Deleted Successfully...!!!");
        }
    }
}
