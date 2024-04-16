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
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // Action method for listing flights
        public async Task<IActionResult> Index()
        {
            var flights = await _context.Flights.ToListAsync();
            return View(flights);
        }

        public async Task<IActionResult> ConfirmBook(int bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            // Retrieve flight details
            var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == booking.ServiceId);

            // Pass flight details and booking details to the view
            ViewData["BookingId"] = booking.Id;
            ViewData["Flight"] = flight;

            return View();
        }

        // Action method for displaying flight details
        public async Task<IActionResult> Details(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("FlightNumber,Origin,Destination,DepartureTime,ArrivalTime,Price")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        public async Task<IActionResult> Search(string searchString, decimal? price)
        {
            var flightQuery = from f in _context.Flights
                              select f;

            bool searchPerformed = !string.IsNullOrEmpty(searchString) || price.HasValue;

            if (searchPerformed)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    flightQuery = flightQuery.Where(f => f.FlightNumber.Contains(searchString)
                                                      || f.Origin.Contains(searchString)
                                                      || f.Destination.Contains(searchString));
                }

                if (price.HasValue)
                {
                    flightQuery = flightQuery.Where(f => f.Price.Equals(price.Value));
                }
            }

            var flights = await flightQuery.ToListAsync();
            ViewData["SearchPerformed"] = searchPerformed;
            ViewData["SearchString"] = searchString;
            ViewData["Price"] = price; // This is for passing back the price in case you want to show it in the view
            return View("Index", flights);
        }
      

        [HttpPost]
        public async Task<IActionResult> Book(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            // Add your booking logic here using the ApplicationDbContext
            var booking = new Booking
            {
                ServiceId = flight.Id,
                ServiceType = "Flight",
                BookingDate = DateTime.Now,
                TotalPrice = flight.Price
                // Set other properties as needed
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Set success message in TempData
            TempData["SuccessMessage"] = "Booking successfully made.";

            return RedirectToAction("ConfirmBook", new { bookingId = booking.Id });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flight/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
