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
    public class CarCategoriesController : ControllerBase
    {
        private readonly SiteContext _context;

        public CarCategoriesController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/CarCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarCategory>>> Getcarcategory()
        {
            return await _context.carcategory.ToListAsync();
        }

        // GET: api/CarCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarCategory>> GetCarCategory(string id)
        {
            var carCategory = await _context.carcategory.FindAsync(id);

            if (carCategory == null)
            {
                return NotFound();
            }

            return carCategory;
        }

        // PUT: api/CarCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarCategory(string id, CarCategory carCategory)
        {
            if (id != carCategory.CatgId)
            {
                return BadRequest();
            }

            _context.Entry(carCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCategoryExists(id))
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

        // POST: api/CarCategories
        [HttpPost]
        public async Task<ActionResult<CarCategory>> PostCarCategory(CarCategory carCategory)
        {
            _context.carcategory.Add(carCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarCategory", new { id = carCategory.CatgId }, carCategory);
        }

        // DELETE: api/CarCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarCategory>> DeleteCarCategory(string id)
        {
            var carCategory = await _context.carcategory.FindAsync(id);
            if (carCategory == null)
            {
                return NotFound();
            }

            _context.carcategory.Remove(carCategory);
            await _context.SaveChangesAsync();

            return carCategory;
        }

        private bool CarCategoryExists(string id)
        {
            return _context.carcategory.Any(e => e.CatgId == id);
        }
    }
}
