using Event_Management_System.Data;
using Event_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CustomerRegistrationsController _context;
        private readonly JwtOption _options;

        public AuthController(CustomerRegistrationsController context, IOptions<JwtOption> options)
        {
            _context = context;
            _options=options.Value;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto model)
        {
            var customer =await _context.GetEmployeeByEmail(model.Email);  
            if(customer == null)
            {
                return BadRequest(new { error = "Email does not exit" });
            }
            if (customer.Password != model.Password)
            {
                return BadRequest(new { error = "Password/email is incorrect" });

            }
            var jwtKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.key));
            var credintials= new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Email",model.Email)
            };
            var sToken = new JwtSecurityToken(_options.key, _options.Issuer, claims, expires: DateTime.Now.AddHours(5), signingCredentials: credintials);

            var token = new JwtSecurityTokenHandler().WriteToken(sToken);
            return Ok(new {token = token});
        }

    }
}