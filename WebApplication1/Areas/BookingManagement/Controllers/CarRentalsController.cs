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
    public class CarRentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action method for listing car rentals
        public async Task<IActionResult> Index()
        {
            var carRentals = await _context.CarRentals.ToListAsync();
            return View(carRentals);
        }

        // Action method for displaying car rental details
        public async Task<IActionResult> Details(int id)
        {
            var carRental = await _context.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }

        [HttpPost]
        public async Task<IActionResult> Book(int id)
        {
            var carRental = await _context.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }

            // Add booking logic here using the ApplicationDbContext
            var booking = new Booking
            {
                ServiceId = carRental.Id,
                ServiceType = "CarRental",
                BookingDate = DateTime.Now,
                TotalPrice = carRental.PricePerDay // Adjust as needed
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

            // Retrieve car rental details
            var carRental = await _context.CarRentals.FirstOrDefaultAsync(c => c.Id == booking.ServiceId);

            // Pass car rental details and booking details to the view
            ViewData["CarRental"] = carRental;
            ViewData["BookingId"] = booking.Id;

            return View();
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var carrentalQuery = from cr in _context.CarRentals
                                 select cr;
            bool searchPerformed = !string.IsNullOrEmpty(searchString);
            if (searchPerformed)
            {
                carrentalQuery = carrentalQuery.Where(cr => cr.Model.Contains(searchString)
                                               || cr.RentalAgency.Contains(searchString)
                                                );
            }
            var car = await carrentalQuery.ToListAsync();
            ViewData["SearchPerformed"] = searchPerformed;
            ViewData["SearchString"] = searchString;
            return View("Index", car);
        }

        // Action method for creating a new car rental
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }


      
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                _context.CarRentals.Add(carRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        // Action method for editing car rental details
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var carRental = await _context.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, CarRental carRental)
        {
            if (id != carRental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(carRental).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        [Authorize(Roles = "Admin")]
        // Action method for deleting a car rental
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carRental = await _context.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carRental = await _context.CarRentals.FindAsync(id);
            _context.CarRentals.Remove(carRental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
