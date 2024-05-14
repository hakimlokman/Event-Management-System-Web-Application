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
    public class OrdersController : ControllerBase
    {
        private readonly EventDbContext _context;
        public OrdersController(EventDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var order = await _context.Orders.ToListAsync();
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(Order order)

        {
            order.TotalCost = order.Quantity * order.UnitPrice;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            existingOrder.EquipmentName = order.EquipmentName;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.DeliveryDate = order.DeliveryDate;
            existingOrder.Quantity = order.Quantity;
            existingOrder.UnitPrice = order.UnitPrice;

            existingOrder.TotalCost = order.Quantity * order.UnitPrice;

            _context.Entry(existingOrder).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(existingOrder);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok("Data Deleted");
        }
    }
}
