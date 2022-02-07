using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class GuestBookingsController : Controller
    {
        private readonly EventsContext _context;

        public GuestBookingsController(EventsContext context)
        {
            _context = context;
        }

        // GET: GuestBookings
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.GuestBookings
                .Include(g => g.Customer)
                .Include(g => g.Event);

            return View(await eventsContext.ToListAsync());
        }

        // GET: GuestBookings/Details/5
        public async Task<IActionResult> Details(int? id, int? eventId)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Checking the composite key in order to return the right result
            var guestBooking = await _context.GuestBookings
                .Include(g => g.Customer)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.CustomerId == id && m.EventId == eventId);
            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }

        // GET: GuestBookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title");
            return View();
        }

        // POST: GuestBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,CustomerId")] GuestBooking guestBooking)
        {
            //Checking to see if the record already exists

            var check = _context.GuestBookings.Find(guestBooking.CustomerId, guestBooking.EventId);

            // If the record already exists
            if (check != null)
            {
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", guestBooking.CustomerId);
                ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventType", guestBooking.EventId);
                ModelState.AddModelError("EventId", "Key already exists"); // Displaying the error
                return View(guestBooking);
            }

            // If record does not exist
            if (ModelState.IsValid)
            {
                _context.Add(guestBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventType", guestBooking.EventId);
            return View(guestBooking);
        }

        // GET: GuestBookings/Edit/5
        public async Task<IActionResult> Edit(int? id, int? eventId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBookings.FindAsync(id, eventId);
            if (guestBooking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title", guestBooking.EventId);
            ViewData["Attendance"] = new SelectList(_context.GuestBookings, "Attendance", "Attendance", guestBooking.Attendance);
            return View(guestBooking);
        }

        // POST: GuestBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int eventId, [Bind("EventId,CustomerId,Attendance")] GuestBooking guestBooking)
        {
            if (id != guestBooking.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestBookingExists(guestBooking.CustomerId, guestBooking.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName", guestBooking.CustomerId);
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title", guestBooking.EventId);
            ViewData["Attendance"] = new SelectList(_context.GuestBookings, "Attendance", "Attendance", guestBooking.Attendance);
            return View(guestBooking);
        }

        // GET: GuestBookings/Delete/5
        public async Task<IActionResult> Delete(int? id, int? eventId)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Only deleting the record if both keys match
            var guestBooking = await _context.GuestBookings
                .Include(g => g.Customer)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.CustomerId == id && m.EventId == eventId);
            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }

        // POST: GuestBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int? eventId)
        {
            var guestBooking = await _context.GuestBookings.FindAsync(id, eventId);
            _context.GuestBookings.Remove(guestBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestBookingExists(int id, int eventId)
        {
            return _context.GuestBookings.Any(e => e.CustomerId == id && e.EventId == eventId);
        }
    }
}
