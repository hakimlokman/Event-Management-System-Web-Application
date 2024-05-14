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
    public class BillController : ControllerBase
    {
        private readonly EventDbContext _context;
        public BillController(EventDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<double> getTotalBill(int customerBookingId)
        {
            var equipmentBill = _context.EquipmentBookings.Where(e => e.CustomerBookingId == customerBookingId).Include(e => e.Equipment).ToList();

            double totalEquipmentBill = (double)equipmentBill.Sum(e => e.DemandQuantity * e.Equipment.UnitPricePerDay);


            var serviceBill = _context.BookingServices.Where(e => e.CustomerBookingId == customerBookingId).Include(e => e.Services).ToList();

            double totalServicesBill = serviceBill.Sum(e => e.Quantity * e.Services.UnitPrice);

            var foodBill = _context.BookingFoods.Where(e => e.CustomerBookingId == customerBookingId).Include(e => e.Food).ToList();

            double totalFoodBill = foodBill.Sum(e => e.Quantity * e.Food.UnitCost);

            double GrandTotal = totalEquipmentBill + totalFoodBill+ totalServicesBill;
            return Ok(GrandTotal);
        }

       

    }
}
