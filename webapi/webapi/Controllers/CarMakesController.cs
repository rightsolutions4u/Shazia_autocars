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
    public class CarMakesController : ControllerBase
    {
        private readonly SiteContext _context;

        public CarMakesController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/CarMakes
        [HttpGet("Getcarmake")]
        public async Task<ActionResult<IEnumerable<CarMake>>> Getcarmake()
        {
            return await _context.carmake.ToListAsync();
        }

        // GET: api/CarMakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarMake>> GetCarMake(string id)
        {
            var carMake = await _context.carmake.FindAsync(id);

            if (carMake == null)
            {
                return NotFound();
            }

            return carMake;
        }

        // PUT: api/CarMakes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarMake(string id, CarMake carMake)
        {
            if (id != carMake.MakeId)
            {
                return BadRequest();
            }

            _context.Entry(carMake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMakeExists(id))
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

        // POST: api/CarMakes
        [HttpPost]
        public async Task<ActionResult<CarMake>> PostCarMake(CarMake carMake)
        {
            _context.carmake.Add(carMake);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarMake", new { id = carMake.MakeId }, carMake);
        }

        // DELETE: api/CarMakes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarMake>> DeleteCarMake(string id)
        {
            var carMake = await _context.carmake.FindAsync(id);
            if (carMake == null)
            {
                return NotFound();
            }

            _context.carmake.Remove(carMake);
            await _context.SaveChangesAsync();

            return carMake;
        }

        private bool CarMakeExists(string id)
        {
            return _context.carmake.Any(e => e.MakeId == id);
        }
    }
}
