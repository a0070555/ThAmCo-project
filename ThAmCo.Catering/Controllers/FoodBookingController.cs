using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Models;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodBookingController : ControllerBase
    {
        private readonly CateringContext _context;

        public FoodBookingController(CateringContext context)
        {
            _context = context;
        }

        // GET: api/FoodBooking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodBooking>>> GetFoodBooking()
        {
            return await _context.FoodBooking.ToListAsync();
        }

        // GET: api/FoodBooking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodBooking>> GetFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBooking.FindAsync(id);

            if (foodBooking == null)
            {
                return NotFound();
            }

            return foodBooking;
        }

        // PUT: api/FoodBooking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodBooking(int id, FoodBooking foodBooking)
        {
            if (id != foodBooking.FoodBookingId)
            {
                return BadRequest();
            }

            _context.Entry(foodBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodBooking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FoodBooking>> PostFoodBooking(FoodBooking foodBooking)
        {
            if (foodBooking == null)
            {
                return BadRequest();
            }
            _context.FoodBooking.Add(foodBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodBooking", new { id = foodBooking.FoodBookingId }, foodBooking);
        }

        // DELETE: api/FoodBooking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodBooking>> DeleteFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBooking.FindAsync(id);
            if (foodBooking == null)
            {
                return NotFound();
            }

            _context.FoodBooking.Remove(foodBooking);
            await _context.SaveChangesAsync();

            return foodBooking;
        }

        private bool FoodBookingExists(int id)
        {
            return _context.FoodBooking.Any(e => e.FoodBookingId == id);
        }
    }
}
