using Event_Management.Models;
using Event_Management_System.Models;
using Event_Management_System.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly EventDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public EmployeesController(EventDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employees.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromForm] EmployeeVM VM)
        {
            
            Employee employee = new Employee
            {
              
                EmployeeName = VM.EmployeeName,
                Address = VM.Address,
                Gender = VM.Gender,
                Designation = VM.Designation,
                Phone = VM.Phone,
                JoinDate = VM.JoinDate,
                DepartmentId=VM.DepartmentId
            };
            //image
            if (VM.ImageFile != null)
            {
                var webroot = _environment.WebRootPath;
                var fileName = DateTime.Now.Ticks.ToString() + Path.GetFileName(VM.ImageFile.FileName);
                var filePath = Path.Combine(webroot, "Images", fileName);

                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await VM.ImageFile.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                fileStream.Close();
                employee.Image = fileName;
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmployee(int id, Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var delEmployee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(delEmployee);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
