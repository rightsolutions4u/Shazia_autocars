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
    public class AutosSellersController : ControllerBase
    {
        private readonly SiteContext _context;

        public AutosSellersController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/AutosSellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutosSeller>>> Getautosseller()
        {
            return await _context.autosseller.ToListAsync();
        }

        // GET: api/AutosSellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutosSeller>> GetAutosSeller(string id)
        {
            var autosSeller = await _context.autosseller.FindAsync(id);

            if (autosSeller == null)
            {
                return NotFound();
            }

            return autosSeller;
        }

        // PUT: api/AutosSellers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutosSeller(string id, AutosSeller autosSeller)
        {
            if (id != autosSeller.SellID)
            {
                return BadRequest();
            }

            _context.Entry(autosSeller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutosSellerExists(id))
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

        // POST: api/AutosSellers
        [HttpPost]
        public async Task<ActionResult<AutosSeller>> PostAutosSeller(AutosSeller autosSeller)
        {
            _context.autosseller.Add(autosSeller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutosSeller", new { id = autosSeller.SellID }, autosSeller);
        }

        // DELETE: api/AutosSellers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutosSeller>> DeleteAutosSeller(string id)
        {
            var autosSeller = await _context.autosseller.FindAsync(id);
            if (autosSeller == null)
            {
                return NotFound();
            }

            _context.autosseller.Remove(autosSeller);
            await _context.SaveChangesAsync();

            return autosSeller;
        }

        private bool AutosSellerExists(string id)
        {
            return _context.autosseller.Any(e => e.SellID == id);
        }
    }
}
