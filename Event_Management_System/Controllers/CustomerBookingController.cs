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
    [Authorize]
    [ApiController]
    public class CustomerBookingController : ControllerBase
    {
        private readonly EventDbContext _context;
        public CustomerBookingController(EventDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ShowVenueVM>> GetVenues()
        {
            var result = from venue in _context.Venues
                         join venuePhoto in _context.VenuePhotoFiles on venue.VenueId equals venuePhoto.VenueId
                         where venue.IsActive == true
                         select new ShowVenueVM
                         {
                             VenueId = venue.VenueId,
                             VenueName = venue.VenueName,
                             VenueAddress = venue.VenueAddress,
                             Capacity = venue.Capacity,
                             VenueDescription = venue.VenueDescription,
                             VenueType = venue.VenueType,
                             IsEnlisted = venue.IsEnlisted,
                             DailyRent = venue.DailyRent,
                             FileName= venuePhoto.FileName
                         };
            var queryResult = result.ToList();
            return queryResult;
        }



        [Route("BookingDetails")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingVM>>> GetAllBooking()
        {
            List<BookingVM> bookingDetails = new List<BookingVM>();

            var allBooking = _context.CustomerBookings.ToList();

            foreach (var booking in allBooking)
            {
                var equipmentList = _context.EquipmentBookings.Where(x => x.CustomerBookingId == booking.CustomerBookingId).Select(x => new EquipmentBooking
                {
                    EquipmentBookingId = x.EquipmentBookingId,
                    CustomerBookingId = x.CustomerBookingId,
                    EquipmentId = x.EquipmentId,
                    DemandQuantity = x.DemandQuantity

                }).ToList();

                var foodList = _context.BookingFoods.Where(x => x.CustomerBookingId == booking.CustomerBookingId).Select(x => new BookingFood
                {
                    BookingFoodId = x.BookingFoodId,
                    Quantity=x.Quantity,
                    CustomerBookingId = x.CustomerBookingId,
                    FoodId = x.FoodId


                }).ToList();

                var serviceList = _context.BookingServices.Where(x => x.CustomerBookingId == booking.CustomerBookingId).Select(x => new BookingServices
                {
                    BookingServicesId = x.BookingServicesId,
                    CustomerBookingId = x.CustomerBookingId,

                    ServicesId = x.ServicesId,
                    Quantity = x.Quantity

                }).ToList();
                bookingDetails.Add(new BookingVM
                {
                    CustomerBookingId = booking.CustomerBookingId,
                    FromDateOfEvent = booking.FromDateOfEvent,
                    ToDateOfEvent = booking.ToDateOfEvent,
                    Remarks = booking.Remarks,
                    NumberOfGuest = booking.NumberOfGuest,
                    VenueId = booking.VenueId,
                    EventId = booking.EventId,

                    EquipmentList = equipmentList.ToArray(),
                    FoodList = foodList.ToArray(),
                    ServiceList = serviceList.ToArray()
                });

            }
            return bookingDetails;
        }






        ///Post Method


        [HttpPost]
        public async Task<ActionResult<CustomerBooking>> CreateBooking([FromForm]BookingVM bookingVM)
         {

            TimeSpan timeSpan = bookingVM.ToDateOfEvent.Date - bookingVM.FromDateOfEvent.Date;

            CustomerBooking customerBooking = new CustomerBooking()
            {
                FromDateOfEvent = bookingVM.FromDateOfEvent,
                ToDateOfEvent = bookingVM.ToDateOfEvent,
                NoOfDays = (int)timeSpan.TotalDays + 1,
                NumberOfGuest = bookingVM.NumberOfGuest,
                Remarks=bookingVM.Remarks,
                VenueId = bookingVM.VenueId,
                EventId = bookingVM.EventId,
                CustomerId=bookingVM.CustomerId
            };
            _context.CustomerBookings.Add(customerBooking);

            var equipmentList = JsonConvert.DeserializeObject<EquipmentBooking[]>(bookingVM.EquipmentStringify);
            var FoodList = JsonConvert.DeserializeObject<BookingFood[]>(bookingVM.FoodStringify);
            var ServiceList = JsonConvert.DeserializeObject<BookingServices[]>(bookingVM.ServicesStringify);
            foreach (var item in equipmentList)
            {
                var equipmentBooking = new EquipmentBooking
                {
                    CustomerBooking = customerBooking,
                    CustomerBookingId=(int)customerBooking.CustomerBookingId,
                    DemandQuantity=item.DemandQuantity,
                    EquipmentId=item.EquipmentId
                };
                _context.Add(equipmentBooking);
            }
            foreach (var item in FoodList)
            {
                var foodBooking = new BookingFood
                {
                    CustomerBooking = customerBooking,
                    CustomerBookingId = (int)customerBooking.CustomerBookingId,
                    Quantity=item.Quantity,
                    FoodId=item.FoodId,
                };
                _context.Add(foodBooking);
            }

            foreach (var item in ServiceList)
            {
                var serviceBooking = new BookingServices
                {
                    CustomerBooking = customerBooking,
                    CustomerBookingId = (int)customerBooking.CustomerBookingId,
                    Quantity = item.Quantity,
                    ServicesId = item.ServicesId
                };
                _context.Add(serviceBooking);
            }
            await _context.SaveChangesAsync();

            var venueBill = _context.CustomerBookings.Where(e => e.CustomerBookingId == customerBooking.CustomerBookingId).Include(x => x.Venue);

            double totalVenueBill = venueBill.Sum(v => v.NoOfDays * v.Venue.DailyRent);


            var equipmentBill = _context.EquipmentBookings.Where(e => e.CustomerBookingId == customerBooking.CustomerBookingId).Include(e => e.Equipment).ToList();
            double totalEquipmentBill = (double)equipmentBill.Sum(e => e.DemandQuantity * e.Equipment.UnitPricePerDay);

            var serviceBill = _context.BookingServices.Where(e => e.CustomerBookingId == customerBooking.CustomerBookingId).Include(e => e.Services).ToList();
            double totalServicesBill = serviceBill.Sum(e => e.Quantity * e.Services.UnitPrice);

            var foodBill = _context.BookingFoods.Where(e => e.CustomerBookingId == customerBooking.CustomerBookingId).Include(e => e.Food).ToList();
            double totalFoodBill = foodBill.Sum(e => e.Quantity * e.Food.UnitCost);

            double grandTotal = totalEquipmentBill + totalFoodBill + totalServicesBill+totalVenueBill;

            // Create Bill
            BillTable bill = new BillTable
            {
                VenueBill = totalVenueBill,
                totalEquipmentBill = totalEquipmentBill,
                totalFoodBill = totalFoodBill,
                totalServicesBill = totalServicesBill,
                GrandTotal = grandTotal,
                CustomerBookingId = customerBooking.CustomerBookingId
            };

            _context.BillTables.Add(bill);
            await _context.SaveChangesAsync();
            return Ok(customerBooking);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<BookingVM>> getBookingDetailsById(int id)
        {
            CustomerBooking customerBooking = await _context.CustomerBookings.FindAsync(id);

            EquipmentBooking[] equipmentList = _context.EquipmentBookings.Where(x => x.CustomerBookingId == customerBooking.CustomerBookingId).Select(x => new EquipmentBooking
                {
                    CustomerBookingId=x.CustomerBookingId,
                    EquipmentBookingId=x.EquipmentBookingId,
                    EquipmentId = x.EquipmentId,
                    DemandQuantity = x.DemandQuantity

                }).ToArray();


            BookingFood[] foodList = _context.BookingFoods.Where(x => x.CustomerBookingId == customerBooking.CustomerBookingId).Select(x => new BookingFood
            {
                CustomerBookingId = x.CustomerBookingId,
                BookingFoodId=x.BookingFoodId,
                Quantity=x.Quantity,
                FoodId = x.FoodId
            }).ToArray();

            BookingServices[] serviceList = _context.BookingServices.Where(x => x.CustomerBookingId == customerBooking.CustomerBookingId).Select(x => new BookingServices
            {
                CustomerBookingId = x.CustomerBookingId,
                BookingServicesId=x.BookingServicesId,
                ServicesId = x.ServicesId,
                Quantity = x.Quantity

            }).ToArray();

            BookingVM bookingVM = new BookingVM()
            {
                CustomerBookingId = customerBooking.CustomerBookingId,
                FromDateOfEvent = customerBooking.FromDateOfEvent,
                ToDateOfEvent = customerBooking.ToDateOfEvent,
                NumberOfGuest = customerBooking.NumberOfGuest,
                Remarks=customerBooking.Remarks,
                VenueId = customerBooking.VenueId,
                EventId = customerBooking.EventId,
                CustomerId=customerBooking.CustomerId,
                EquipmentList = equipmentList,
                FoodList = foodList,
                ServiceList = serviceList
            };

            return bookingVM;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerBooking>> UpdateBooking([FromForm] BookingVM bookingVM, int id)
        {
            var existingBooking = await _context.CustomerBookings
                                                .Include(cb => cb.EquipmentBookings)
                                                .Include(cb => cb.BookingFood)
                                                .Include(cb => cb.BookingServices)
                                                .FirstOrDefaultAsync(x => x.CustomerBookingId == id);

            if (existingBooking == null)
            {
                return NotFound();
            }

            // Update the properties of the existing booking
            existingBooking.FromDateOfEvent = bookingVM.FromDateOfEvent;
            existingBooking.ToDateOfEvent = bookingVM.ToDateOfEvent;
            existingBooking.NumberOfGuest = bookingVM.NumberOfGuest;
            existingBooking.Remarks = bookingVM.Remarks;
            existingBooking.VenueId = bookingVM.VenueId;
            existingBooking.EventId = bookingVM.EventId;
            existingBooking.CustomerId = bookingVM.CustomerId;

            // Update EquipmentBookings
            _context.EquipmentBookings.RemoveRange(existingBooking.EquipmentBookings);
            var equipmentList = JsonConvert.DeserializeObject<EquipmentBooking[]>(bookingVM.EquipmentStringify);
            foreach (var item in equipmentList)
            {
                var equipmentBooking = new EquipmentBooking
                {
                    CustomerBookingId = existingBooking.CustomerBookingId,
                    DemandQuantity = item.DemandQuantity,
                    EquipmentId = item.EquipmentId
                };
                existingBooking.EquipmentBookings.Add(equipmentBooking);
            }

            // Update BookingFood
            _context.BookingFoods.RemoveRange(existingBooking.BookingFood);
            var foodList = JsonConvert.DeserializeObject<BookingFood[]>(bookingVM.FoodStringify);
            foreach (var item in foodList)
            {
                var foodBooking = new BookingFood
                {
                    CustomerBookingId = existingBooking.CustomerBookingId,
                    Quantity = item.Quantity,
                    FoodId = item.FoodId,
                };
                existingBooking.BookingFood.Add(foodBooking);
            }

            // Update BookingServices
            _context.BookingServices.RemoveRange(existingBooking.BookingServices);
            var serviceList = JsonConvert.DeserializeObject<BookingServices[]>(bookingVM.ServicesStringify);
            foreach (var item in serviceList)
            {
                var serviceBooking = new BookingServices
                {
                    CustomerBookingId = existingBooking.CustomerBookingId,
                    Quantity = item.Quantity,
                    ServicesId = item.ServicesId
                };
                existingBooking.BookingServices.Add(serviceBooking);
            }

            await _context.SaveChangesAsync();
            return Ok(existingBooking);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerBooking>> DeleteBooking(int id)
        {
            CustomerBooking delCustomerBooking = _context.CustomerBookings.Find(id);

            if(delCustomerBooking != null)
            {
                var delEquipment = _context.EquipmentBookings.Where(x => x.CustomerBookingId == delCustomerBooking.CustomerBookingId).ToList();

                var delFood = _context.BookingFoods.Where(x => x.CustomerBookingId == delCustomerBooking.CustomerBookingId).ToList();

                var delServices = _context.BookingServices.Where(x => x.CustomerBookingId == delCustomerBooking.CustomerBookingId).ToList();

                _context.CustomerBookings.Remove(delCustomerBooking);
                _context.EquipmentBookings.RemoveRange(delEquipment);
                _context.BookingFoods.RemoveRange(delFood);
                _context.BookingServices.RemoveRange(delServices);             
            }
            await _context.SaveChangesAsync();

            return Ok("Successfully Deleted !!");
        }

    }
}
