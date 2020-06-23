using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class AutosVehiclesController : ControllerBase
    {
        private readonly SiteContext _context;

        public AutosVehiclesController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/AutosVehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> GetAutosVehicle()
        {
            var autosVehicle= await _context.AutosVehicle.Where(a =>  a.IsSold == 0
                           )
                            .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory).ToListAsync();
            return autosVehicle;
        }

        // GET: api/AutosVehicles
        [HttpGet("GetFeatuedAutos")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> GetFeatuedAutos()
        {
           return await _context.AutosVehicle.Where(a => a.IsFeatured == 1 && a.IsSold != 1
                            && a.IsReserved != 1 && a.IsTrendy == 1)
                            .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory)
                            .ToListAsync();
            
        }
        // GET: api/AutosVehicles
        [HttpGet("GetTrendyAutos")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> GetTrendyAutos()
        {
            return await _context.AutosVehicle.Where(a => a.IsFeatured != 1 && a.IsSold != 1
                            && a.IsReserved == 1 && a.IsTrendy == 1)
                            .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory)
                            .ToListAsync();

        }
        // GET: api/AutosVehicles/5
        [HttpGet("GetAutosVehicle/{id}")]
        public async Task<ActionResult<AutosVehicle>> GetAutosVehicle(int id)
        {
            var autosVehicle = await _context.AutosVehicle.FindAsync(id);


            if (autosVehicle == null )
            {
                return NotFound();
            }
            else if (autosVehicle.IsSold==1)
            {
                return NotFound();
            }
            
            return autosVehicle;
        }
        // PUT: api/AutosVehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutosVehicle(int id, AutosVehicle autosVehicle)
        {
            if (id != autosVehicle.AutoId)
            {
                return BadRequest();
            }

            _context.Entry(autosVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutosVehicleExists(id))
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

        // POST: api/AutosVehicles
        [HttpPost]
        public async Task<ActionResult<AutosVehicle>> PostAutosVehicle(AutosVehicle autosVehicle)
        {
            _context.AutosVehicle.Add(autosVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutosVehicle", new { id = autosVehicle.AutoId }, autosVehicle);
        }

        // DELETE: api/AutosVehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutosVehicle>> DeleteAutosVehicle(int id)
        {
            var autosVehicle = await _context.AutosVehicle.FindAsync(id);
            if (autosVehicle == null)
            {
                return NotFound();
            }

            _context.AutosVehicle.Remove(autosVehicle);
            await _context.SaveChangesAsync();

            return autosVehicle;
        }

        private bool AutosVehicleExists(int id)
        {
            var a = _context.AutosVehicle.Any(e => e.AutoId == id);
            return a;

        }
        
        

    }
    }






