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
    public class StaffingController : Controller
    {
        private readonly EventsContext _context;

        public StaffingController(EventsContext context)
        {
            _context = context;
        }

        // GET: Staffing
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.Staffing.Include(s => s.Event).Include(s => s.Staff);
            return View(await eventsContext.ToListAsync());
        }

        // GET: Staffing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffing
                .Include(s => s.Event)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (staffing == null)
            {
                return NotFound();
            }

            return View(staffing);
        }

        // GET: Staffing/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FullName");
            return View();
        }

        // POST: Staffing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,StaffId")] Staffing staffing)
        {
            //Checking to see if the record already exists
            var check = _context.Staffing.Find(staffing.EventId, staffing.StaffId);

            // If the record exists
            if (check != null)
            {
                ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title", staffing.EventId);
                ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FullName", staffing.StaffId);
                ModelState.AddModelError("EventId", "Key already exists"); // Displaying error
                return View(staffing);
            }

            // If record does not exist
            if (ModelState.IsValid)
            {
                _context.Add(staffing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FullName", staffing.StaffId);
            return View(staffing);
        }

        // GET: Staffing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffing.FindAsync(id);
            if (staffing == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FullName", staffing.StaffId);
            return View(staffing);
        }

        // POST: Staffing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,StaffId")] Staffing staffing)
        {
            if (id != staffing.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffingExists(staffing.EventId, staffing.StaffId))
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
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "Title", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "FullName", staffing.StaffId);
            return View(staffing);
        }

        // GET: Staffing/Delete/5
        public async Task<IActionResult> Delete(int? id, int? staffId)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Ensuring it only deletes if both keys match
            var staffing = await _context.Staffing
                .Include(s => s.Event)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.EventId == id && m.StaffId == staffId);
            if (staffing == null)
            {
                return NotFound();
            }

            return View(staffing);
        }

        // POST: Staffing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int staffId)
        {
            var staffing = await _context.Staffing.FindAsync(id, staffId);
            _context.Staffing.Remove(staffing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffingExists(int id, int staffId)
        {
            return _context.Staffing.Any(e => e.EventId == id && e.StaffId == staffId);
        }
    }
}
