using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using webapi.Migrations;

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
            var autosVehicle = await _context.AutosVehicle.Where(a => a.IsSold == 0
                           )
                            .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory)
                            .Include(a => a.AutosImages)
                            .Where(a => a.AutosImages.Any(f => f.AutoId == a.AutoId))
                            .ToListAsync();
            return autosVehicle;
        }
        // GET: api/AutosVehicles
        [HttpGet("GetFeatuedAutos")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> GetFeatuedAutos()
        {
            var A = await _context.AutosVehicle.Where(a => a.IsFeatured == 1 && a.IsSold != 1
                              && a.IsReserved != 1 && a.IsTrendy != 1)
                              .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory)
                            .Include(a => a.AutosFeatures)
                            .Include(a => a.AutosImages)
                            //.Where(a => a.AutosImages.Any(f => f.AutosID == a.AutoId)
                            //)
                            .ToListAsync();

           
            return A;

        }
        // GET: api/AutosVehicles
        [HttpGet("GetTrendyAutos")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> GetTrendyAutos()
        {
            //sold cars are trendy
            var A = await _context.AutosVehicle.Where(a => a.IsFeatured != 1 && a.IsSold == 1
                              && a.IsReserved != 1 && a.IsTrendy == 1)
                              .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory)
                            .Include(a => a.AutosFeatures)
                            //.Include(a => a.AutosImages).Where(a => a.AutosImages.Any(f => f.AutoId == a.AutoId)
                            //)
                            .ToListAsync();


            return A;

        }

        // GET: api/AutosVehicles
        [HttpPost("SearchCars")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> SearchCars
            (AutosVehicle input, int PowerFrom, int PowerTo, int FromMil, int ToMil, string ABS , string fourwheel)
        {
           var A= await _context.AutosVehicle.Where(a => a.IsSold != 1
                                 && a.IsReserved != 1
                                 && (input.MakeId.Contains("x") || a.MakeId == input.MakeId)
                                 && (input.ModlId.Contains("x") || a.ModlId == input.ModlId)
                                 && (input.Acolor.Contains("x") || a.Acolor == input.Acolor)
                                 && (input.BodyId.Contains("x") || a.BodyId == input.BodyId)
                                 && (input.Engine.Contains("x") || a.Engine == input.Engine)
                                 && (input.FuelType.Contains("x") || a.FuelType == input.FuelType)
                                 && ((PowerTo == 0) || (a.Power >= PowerFrom && a.Power <= PowerTo))
                                 && ((ToMil == 0) || ((a.Mileag >= FromMil) && (a.Mileag <= ToMil)))
                                 && ((input.Volume == 0) || a.Volume == input.Volume)
                                 && ((input.Cosumption == 0) || a.Cosumption == input.Cosumption)
                                 && ((input.AuYear == 0) || a.AuYear == input.AuYear)
                                 && ((input.NoOfDoors == 0) || a.NoOfDoors == input.NoOfDoors)
                                 && ((input.SellPri == 0) || a.SellPri == input.SellPri)
                                 && ((input.Seater == 0) || a.Seater == input.Seater)
                                 )
                            .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory)
                            .Include(a => a.AutosFeatures)
                            //.Where(a => a.AutosFeatures.Any(f =>  (ABS.Contains("x")||f.FEATID == ABS)
                            //                                       && (fourwheel.Contains("x") || f.FEATID == fourwheel)
                            //&&(f.AutoId==a.AutoId)))
                           .ToListAsync();
        return A;
        }
        [HttpGet("SearchCarsBrands")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> SearchCarsBrands(string Brand)
        {
            
            //return await _context.AutosVehicle.FromSql("GetAutosVehiclesBrands1) @whereclause",
            //   new MySqlParameter("whereclause", Brand1)
            //   ).ToListAsync();
            var A = await _context.AutosVehicle.Where(a => a.IsSold != 1
                                              && a.IsReserved != 1)
                                             .Include(a => a.CarBody)
                                             .Include(a => a.CarModel)
                                             .Include(a => a.CarCategory)
                                             .Include(a => a.CarMake).Where(f => f.CarMake.MkDesc== Brand)
                                             .ToListAsync();
            return A;
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






