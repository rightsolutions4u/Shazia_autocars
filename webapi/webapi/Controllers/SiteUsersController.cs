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
    public class SiteUsersController : ControllerBase
    {
        private readonly SiteContext _context;

        public SiteUsersController(SiteContext context)
        {
            _context = context;
        }

        // GET: api/SiteUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteUsers>>> GetSiteUsers()
        {
            return await _context.SiteUsers.ToListAsync();
        }

        // GET: api/SiteUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SiteUsers>> GetSiteUsers(string id)
        {
            var siteUsers = await _context.SiteUsers.FindAsync(id);

            if (siteUsers == null)
            {
                return NotFound();
            }

            return siteUsers;
        }

        // PUT: api/SiteUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiteUsers(string id, SiteUsers siteUsers)
        {
            if (id != siteUsers.UserId)
            {
                return BadRequest();
            }

            _context.Entry(siteUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteUsersExists(id))
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

        // POST: api/SiteUsers
        [HttpPost("CreateSiteUsers")]
        public async Task<ActionResult<SiteUsers>> CreateSiteUsers(SiteUsers siteUsers)
        {
            _context.SiteUsers.Add(siteUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiteUsers", new { id = siteUsers.UserId }, siteUsers);
        }

        private bool SiteUsersExists(string id)
        {
            return _context.SiteUsers.Any(e => e.UserId == id);
        }
        

        [HttpGet("CheckLogin")]
        public async Task<ActionResult<SiteUsers>> CheckLogin(string id, string UserPassword)
        {
            bool UserExists;
            UserExists = _context.SiteUsers.Any(e => e.UserId == id && e.UserPassword == UserPassword);

            if (UserExists == false)
            {
                return NotFound();
            }
            var siteUsers = await _context.SiteUsers.FindAsync(id);
            return siteUsers;

        }

    }
}
