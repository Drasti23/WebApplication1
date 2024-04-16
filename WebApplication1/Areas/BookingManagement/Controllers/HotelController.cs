using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Areas.BookingManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Areas.BookingManagement.Controllers
{
    [Area("BookingManagement")]
    [Route("[area]/[controller]/[action]")]
    [Authorize]
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action method for listing hotels
        public async Task<IActionResult> Index()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return View(hotels);
        }

        [HttpPost]
        public async Task<IActionResult> Book(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            // Add booking logic here using the ApplicationDbContext
            var booking = new Booking
            {
                ServiceId = hotel.Id,
                ServiceType = "Hotel",
                BookingDate = DateTime.Now,
                TotalPrice = hotel.PricePerNight // Adjust as needed
                // Add other booking properties as needed
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Set success message to display on the Book view
            TempData["SuccessMessage"] = "Booking successfully made.";

            return RedirectToAction("ConfirmBook", new { bookingId = booking.Id });
        }
        public async Task<IActionResult> ConfirmBook(int bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            // Retrieve hotel details
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == booking.ServiceId);

            // Pass hotel details and booking details to the view
            ViewData["Hotel"] = hotel;
            ViewData["BookingId"] = booking.Id;

            return View();
        }

        // Action method for displaying hotel details
        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var hotelQuery = from h in _context.Hotels
                             select h;
            bool searchPerformed = !string.IsNullOrEmpty(searchString);
            if (searchPerformed)
            {
                hotelQuery = hotelQuery.Where(h => h.Name.Contains(searchString)
                                               || h.Location.Contains(searchString)
                                                );
            }
            var hotels = await hotelQuery.ToListAsync();
            ViewData["SearchPerformed"] = searchPerformed;
            ViewData["SearchString"] = searchString;
            return View("Index", hotels);
        }

        // Action method for creating a new hotel
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Hotels.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // Action method for editing hotel details
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(hotel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // Action method for deleting a hotel
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }


        [Authorize(Roles = "Admin")]

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
