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
    public class AutosImagesController : ControllerBase
    {
        private readonly SiteContext _context;

        public AutosImagesController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/AutosImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutosImages>>> GetAutosImages()
        {
            return await _context.AutosImages.ToListAsync();
        }

        // GET: api/AutosImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutosImages>> GetAutosImages(int id)
        {
            var autosImages = await _context.AutosImages.FindAsync(id);

            if (autosImages == null)
            {
                return NotFound();
            }

            return autosImages;
        }

        // PUT: api/AutosImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutosImages(int id, AutosImages autosImages)
        {
            if (id != autosImages.ImageID)
            {
                return BadRequest();
            }

            _context.Entry(autosImages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutosImagesExists(id))
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

        // POST: api/AutosImages
        [HttpPost]
        public async Task<ActionResult<AutosImages>> PostAutosImages(AutosImages autosImages)
        {
            _context.AutosImages.Add(autosImages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutosImages", new { id = autosImages.ImageID }, autosImages);
        }

        // DELETE: api/AutosImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutosImages>> DeleteAutosImages(int id)
        {
            var autosImages = await _context.AutosImages.FindAsync(id);
            if (autosImages == null)
            {
                return NotFound();
            }

            _context.AutosImages.Remove(autosImages);
            await _context.SaveChangesAsync();

            return autosImages;
        }

        private bool AutosImagesExists(int id)
        {
            return _context.AutosImages.Any(e => e.ImageID == id);
        }
    }
}
