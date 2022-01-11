using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab5.Models;

namespace lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class lab5ItemController : ControllerBase
    {
        private readonly aspNetlab5Context _context;

        public lab5ItemController(aspNetlab5Context context)
        {
            _context = context;
        }

        // GET: api/lab5Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<aspNetlab5Item>>> Getlab5Items()
        {
            return await _context.aspNetlab5.ToListAsync();
        }

        // GET: api/lab5Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<aspNetlab5Item>> Getlab5Item(long id)
        {
            var aspnetlab5Item = await _context.aspNetlab5.FindAsync(id);

            if (aspnetlab5Item == null)
            {
                return NotFound();
            }

            return aspnetlab5Item;
        }

        // PUT: api/lab5Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlab5Item(long id, aspNetlab5Item aspNetlab5Item)
        {
            if (id != aspNetlab5Item.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetlab5Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lab5ItemExists(id))
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

        // POST: api/lab5Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<aspNetlab5Item>> Postlab5Item(aspNetlab5Item aspNetlab5Item)
        {
            _context.aspNetlab5.Add(aspNetlab5Item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlab5Item", new { id = aspNetlab5Item.Id }, aspNetlab5Item);
        }

        // DELETE: api/lab5Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelab5Item(long id)
        {
            var aspnetlab5Item = await _context.aspNetlab5.FindAsync(id);
            if (aspnetlab5Item == null)
            {
                return NotFound();
            }

            _context.aspNetlab5.Remove(aspnetlab5Item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool lab5ItemExists(long id)
        {
            return _context.aspNetlab5.Any(e => e.Id == id);
        }
    }
}
