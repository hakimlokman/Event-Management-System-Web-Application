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
    public class DepartmentsController : ControllerBase
    {
        private readonly EventDbContext _context;
        public DepartmentsController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            return await _context.Departments.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var departments = await _context.Departments.FindAsync(id);
            return Ok(departments);
        }
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok(department);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutDepartment(int id, Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            return Ok(department);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var delDepartment = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(delDepartment);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
