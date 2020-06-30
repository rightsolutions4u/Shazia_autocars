﻿using System;
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
                            .Include(a => a.CarCategory)
                            //.Include(a => a.AutosImages.SingleOrDefault() )
                            .ToListAsync();
            return autosVehicle;
        }
       

        // GET: api/AutosVehicles
        [HttpGet("GetFeatuedAutos")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> GetFeatuedAutos()
        {
            var A = await _context.AutosVehicle.Where(a => a.IsFeatured == 1 && a.IsSold != 1
                              && a.IsReserved != 1 && a.IsTrendy == 1 )
                              .Include(a => a.CarBody)
                            .Include(a => a.CarMake)
                            .Include(a => a.CarModel)
                            .Include(a => a.CarCategory)
                            .ToListAsync();
                      
            return A;
            
        }
        // GET: api/AutosVehicles
        [HttpPost("SearchCars")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> SearchCars(AutosVehicle input)
        {        
            return await _context.AutosVehicle.Where(a => a.IsSold != 1
                                  && a.IsReserved != 1 
                                 //&& a.MakeId == "3" && a.ModlId == "3"
                                 && (input.MakeId.Contains("x") || a.MakeId == input.MakeId)
                                 && (input.ModlId.Contains("x") || a.ModlId == input.ModlId)
                                 && (input.Acolor.Contains("x") || a.Acolor == input.Acolor)
                                 && (input.BodyId.Contains("x") || a.BodyId == input.BodyId)
                                 && (input.Engine.Contains("x") || a.Engine == input.Engine)
                                 && (input.FuelType.Contains("x") || a.FuelType == input.FuelType)

                                  //&& (input.Mileag.Contains("x") || a.Mileag == input.Mileag)
                                  //&& (input.Power.Contains("x") || a.Power == input.Power)
                                  //&& ((input.AutoId != 0) || a.AutoId == input.AutoId)
                                  //&& ((input.Volume != 0) || a.Volume == input.Volume)
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
                               //.Include(a => a.AutosFeatures)
                               //  .ThenInclude(b => b.Vehiclefeatures)
                               .ToListAsync();

            

        }
        // GET: api/AutosVehicles
        [HttpPost("SearchCars2")]
        public async Task<ActionResult<IEnumerable<AutosVehicle>>> SearchCars2(string pMakeId, string pModlId,
                    string pAcolor)
        {
            return await _context.AutosVehicle.Where(a => a.IsSold != 1
                                  && a.IsReserved != 1 
                                 //&& a.MakeId == "2" && a.ModlId == "3" 
                                 && (string.IsNullOrEmpty(pAcolor) || a.Acolor == pAcolor)
                                 && (string.IsNullOrEmpty(pMakeId) || a.MakeId == pMakeId)
                                 && (string.IsNullOrEmpty(pModlId) || a.ModlId == pModlId)

                                 //&& (string.IsNullOrEmpty(input.BodyId) || a.BodyId == input.BodyId)
                                 //&& ((input.Cosumption != 0) || a.Cosumption == input.Cosumption)
                                 //&& ((input.AutoId != 0) || a.AutoId == input.AutoId)
                                 //&& ((input.AuYear != 0) || a.AuYear == input.AuYear)
                                 //&& ((input.NoOfDoors != 0) || a.NoOfDoors == input.NoOfDoors)
                                 //&& (string.IsNullOrEmpty(input.Engine) || a.Engine == input.Engine)
                                 //&& (string.IsNullOrEmpty(input.FuelType) || a.FuelType == input.FuelType)
                                 //&& (string.IsNullOrEmpty(input.Mileag) || a.Mileag == input.Mileag)
                                 //&& (string.IsNullOrEmpty(input.Power) || a.Mileag == input.Power)
                                 //&& ((input.Volume != 0) || a.Volume == input.Volume)
                                 //&& ((input.SellPri != 0) || a.SellPri == input.SellPri)
                                 //&& ((input.Seater != 0) || a.Seater == input.Seater)
                                 )
                               .Include(a => a.CarBody)
                               .Include(a => a.CarMake)
                               .Include(a => a.CarModel)
                               .Include(a => a.CarCategory)
                               //.Include(a => a.AutosFeatures)
                               //  .ThenInclude(b => b.Vehiclefeatures)
                               .ToListAsync();
        }

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






