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
    public class MenuFoodItemController : ControllerBase
    {
        private readonly CateringContext _context;

        public MenuFoodItemController(CateringContext context)
        {
            _context = context;
        }

        // GET: api/MenuFoodItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuFoodItem>>> GetMenuFoodItem()
        {
            return await _context.MenuFoodItem.ToListAsync();
        }

        // GET: api/MenuFoodItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuFoodItem>> GetMenuFoodItem(int id)
        {
            var menuFoodItem = await _context.MenuFoodItem.FindAsync(id);

            if (menuFoodItem == null)
            {
                return NotFound();
            }

            return menuFoodItem;
        }

        // PUT: api/MenuFoodItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuFoodItem(int id, MenuFoodItem menuFoodItem)
        {
            if (id != menuFoodItem.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menuFoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuFoodItemExists(id))
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

        // POST: api/MenuFoodItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MenuFoodItem>> PostMenuFoodItem(MenuFoodItem menuFoodItem)
        {
            _context.MenuFoodItem.Add(menuFoodItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuFoodItemExists(menuFoodItem.MenuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuFoodItem", new { id = menuFoodItem.MenuId }, menuFoodItem);
        }

        // DELETE: api/MenuFoodItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuFoodItem>> DeleteMenuFoodItem(int id)
        {
            var menuFoodItem = await _context.MenuFoodItem.FindAsync(id);
            if (menuFoodItem == null)
            {
                return NotFound();
            }

            _context.MenuFoodItem.Remove(menuFoodItem);
            await _context.SaveChangesAsync();

            return menuFoodItem;
        }

        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItem.Any(e => e.MenuId == id);
        }
    }
}
