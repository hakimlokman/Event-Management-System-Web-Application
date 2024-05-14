using Event_Management.Models;
using Event_Management_System.Models;
using Event_Management_System.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VenuesController : ControllerBase
    {
        private readonly EventDbContext _context;
        private readonly IWebHostEnvironment _he;

        public VenuesController(EventDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;

        }
        [HttpGet]
        public async Task<IEnumerable<Venue>> GetVenues()
        {
            return await _context.Venues.ToListAsync();
        }

        [HttpGet]
        [Route("VenuePhoto")]
        public async Task<IEnumerable<VenuePhotoFile>> VenuePhoto()
        {
            return await _context.VenuePhotoFiles.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> CreateVenue([FromForm] VenuePhotoVM venuePhotoVM)
        {
            Venue venue = new Venue
            {
                VenueId= venuePhotoVM.VenueId,
                VenueName = venuePhotoVM.VenueName,
                VenueAddress = venuePhotoVM.VenueAddress,
                VenueDescription = venuePhotoVM.VenueDescription,
                Capacity = venuePhotoVM.Capacity,
                DailyRent = venuePhotoVM.DailyRent,
                IsEnlisted = venuePhotoVM.IsEnlisted,
                VenueType=venuePhotoVM.VenueType
               
            };
            _context.Venues.Add(venue);

            await _context.SaveChangesAsync();
            var lastVenueId = venue.VenueId;

            foreach (var item in venuePhotoVM.VenuePhoto)
            {
                if (item.FileName == null || item.FileName.Length == 0)
                {
                    return Content("File not selected");

                }

                var path = Path.Combine(_he.WebRootPath, "Images", item.FileName);
                using (FileStream stream =new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                    stream.Close();
                }
                var venuePhotoFile = new VenuePhotoFile
                {
                    VenueId= lastVenueId,
                    FileName = item.FileName,
                    ImagesPath=path

                };
                _context.Add(venuePhotoFile);
                await _context.SaveChangesAsync();
            }
            return Ok(venue);
        }
    }
}
