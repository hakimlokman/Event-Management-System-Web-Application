using Event_Management.Models;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceTypesController : ControllerBase
    {
        private readonly EventDbContext _context;
        public ServiceTypesController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypes()
        {
            var serviceType = await _context.ServiceTypes.ToListAsync();
            return Ok(serviceType);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceType(int id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return serviceType;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceType>> AddServiceType(ServiceType serviceType)
        {
            await _context.ServiceTypes.AddAsync(serviceType);
            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceType>> UpdateServiceType(int id, ServiceType serviceType)
        {
            if (id != serviceType.ServiceTypeId)
            {
                return BadRequest();
            }
            _context.Entry(serviceType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(serviceType);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceType>> DeleteServiceType(int id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }
            _context.ServiceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();
            return Ok("Data Deleted Successfully...!!!");
        }
    }
}
