using Event_Management.Models;
using Event_Management_System.Models.ViewModels;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerRegistrationsController : ControllerBase
    {
        private readonly EventDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CustomerRegistrationsController(EventDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        
        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<CustomerRegistration>>> GetCustomerRegistration()
        {
            return await _context.CustomerRegistrations.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerRegistration>> GetCustomerRegistration(int id)
        {
            var customer = await _context.CustomerRegistrations.FindAsync(id);
            return Ok(customer);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CustomerRegistration>> PostCustomerRegistration([FromForm] CustomerRegistrationVM VM)
        {
            CustomerRegistration customer = new CustomerRegistration
            {
                FirstName = VM.FirstName,
                LastName = VM.LastName,
                Gender = VM.Gender,
                DateOfBirth = VM.DateOfBirth,
                Address = VM.Address,
                Phone = VM.Phone,
                Email = VM.Email,
                RegistrationDate = DateTime.Now
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
                customer.Image = fileName;
            }
            _context.CustomerRegistrations.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutCustomerRegistration(int id, CustomerRegistration customer)
        //{
        //    _context.Entry(customer).State = EntityState.Modified;
        //    return Ok(customer);
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerRegistration(int id)
        {
            var delCustomer = await _context.CustomerRegistrations.FindAsync(id);
            _context.CustomerRegistrations.Remove(delCustomer);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }


        [ApiExplorerSettings(IgnoreApi = true)]

        public async Task<CustomerRegistration> GetEmployeeByEmail(string email)
        {
            return await _context.CustomerRegistrations.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
