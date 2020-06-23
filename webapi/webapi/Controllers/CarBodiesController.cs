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
    public class CarBodiesController : ControllerBase
    {
        private readonly SiteContext _context;

        public CarBodiesController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/CarBodies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarBody>>> Getcarbody()
        {
            return await _context.carbody.ToListAsync();
        }

        // GET: api/CarBodies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarBody>> GetCarBody(string id)
        {
            var carBody = await _context.carbody.FindAsync(id);

            if (carBody == null)
            {
                return NotFound();
            }

            return carBody;
        }

        // PUT: api/CarBodies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarBody(string id, CarBody carBody)
        {
            if (id != carBody.BodyId)
            {
                return BadRequest();
            }

            _context.Entry(carBody).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarBodyExists(id))
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

        // POST: api/CarBodies
        [HttpPost]
        public async Task<ActionResult<CarBody>> PostCarBody(CarBody carBody)
        {
            _context.carbody.Add(carBody);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarBody", new { id = carBody.BodyId }, carBody);
        }

        // DELETE: api/CarBodies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarBody>> DeleteCarBody(string id)
        {
            var carBody = await _context.carbody.FindAsync(id);
            if (carBody == null)
            {
                return NotFound();
            }

            _context.carbody.Remove(carBody);
            await _context.SaveChangesAsync();

            return carBody;
        }

        private bool CarBodyExists(string id)
        {
            return _context.carbody.Any(e => e.BodyId == id);
        }
    }
}
