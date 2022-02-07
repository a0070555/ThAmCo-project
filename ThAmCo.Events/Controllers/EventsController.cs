using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.DTOs;
using ThAmCo.Events.Models;
using ThAmCo.Events.ViewModels.EventViewModels;

namespace ThAmCo.Events.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsContext _context;
        public EventsController(EventsContext context)
        {
            _context = context;

        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            // Ensuring no deleted events are listed
             var eventsList = await _context.Events
                .Where(e => !e.IsDeleted)
                .ToListAsync();

            return View(eventsList);
        }

        // GET: Events/Guests/5
        public async Task<IActionResult> Guests(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Not returning the requested events if they are deleted
            var @event = await _context
                .Events
                .FirstOrDefaultAsync(m => m.EventId == id && !m.IsDeleted);

            if (@event == null)
            {
                return NotFound();
            }

            // Getting all the guests associated with the event
            var guests = _context.GuestBookings
                .Where(g => g.EventId == id)
                .Include(g => g.Customer)
                .Include(g => g.Event);

            return View(guests);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Using and populating the view model
            EventDetailsViewModel @event = await _context.Events
                .Select(m => new EventDetailsViewModel
                {
                    EventId = m.EventId,
                    Title = m.Title,
                    EventDate = m.EventDate,
                    EventType = m.EventType
                })
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Title,EventDate,EventType,IsDeleted")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Title")] EditEventDto @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Getting the event details
                    var @eventDetails = await _context.Events.FindAsync(id);
                    if (@eventDetails == null)
                    {
                        return NotFound();
                    }

                    // Setting the only value of the DTO that should be updated
                    @eventDetails.Title = @event.Title;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            return View(@event);
        }


        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
