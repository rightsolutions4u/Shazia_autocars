using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosBuyersController : ControllerBase
    {
        private readonly SiteContext _context;

        public AutosBuyersController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/AutosBuyers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutosBuyer>>> Getautosbuyer()
        {
            return await _context.autosbuyer.ToListAsync();
        }

        // GET: api/AutosBuyers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutosBuyer>> GetAutosBuyer(string id)
        {
            var autosBuyer = await _context.autosbuyer.FindAsync(id);

            if (autosBuyer == null)
            {
                return NotFound();
            }

            return autosBuyer;
        }

        // PUT: api/AutosBuyers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutosBuyer(string id, AutosBuyer autosBuyer)
        {
            if (id != autosBuyer.BuyrID)
            {
                return BadRequest();
            }

            _context.Entry(autosBuyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutosBuyerExists(id))
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

        // POST: api/AutosBuyers
        [HttpPost]
        public async Task<ActionResult<AutosBuyer>> PostAutosBuyer(AutosBuyer autosBuyer)
        {
            _context.autosbuyer.Add(autosBuyer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutosBuyer", new { id = autosBuyer.BuyrID }, autosBuyer);
        }

        // DELETE: api/AutosBuyers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutosBuyer>> DeleteAutosBuyer(string id)
        {
            var autosBuyer = await _context.autosbuyer.FindAsync(id);
            if (autosBuyer == null)
            {
                return NotFound();
            }

            _context.autosbuyer.Remove(autosBuyer);
            await _context.SaveChangesAsync();

            return autosBuyer;
        }

        private bool AutosBuyerExists(string id)
        {
            return _context.autosbuyer.Any(e => e.BuyrID == id);
        }
    }
}
