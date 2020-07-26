using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;
using Newtonsoft.Json;


namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : Controller
    {
        private readonly SiteContext _context;

        public CarModelsController(SiteContext context)
        {
            _context = context;
        }

        //GET: api/CarModels
       [HttpGet("GetcarmodelbyMake")]
         public async Task<ActionResult<IEnumerable<CarModel>>> GetcarmodelbyMake(string MakeID)
        {
           
            var A = await _context.carmodel.Where(e => e.MakeId == MakeID)
            .ToListAsync();
            return Ok(A);
            //below code converts Json data to string
           // return Json(null != A ? JsonConvert.SerializeObject(A) : "{'message':'no data found'}");
            //return A ; sends Json data object/array
                 }

        //GET: api/CarModels
        [HttpGet("GetcarmodelbyMake2")]
           public JsonResult GetcarmodelbyMake2(string MakeID)
        {
            Task<ActionResult<IEnumerable<CarModel>>> carModel = Getcarmodelbymake1(MakeID);
            //return Json(carModel,/*new { data = carModel }*/);
            //var a = JsonConvert.SerializeObject(carModel);
            return Json(null != carModel ? JsonConvert.SerializeObject(carModel) : "{'message':'no data found'}");
            
        }
        //GET: api/CarModels
        [HttpGet("Getcarmodelbymake1")]
        public async Task<ActionResult<IEnumerable<CarModel>>> Getcarmodelbymake1(string MakeID)
        {
            var A = await _context.carmodel.Where(e => e.MakeId == MakeID)
            .ToListAsync();
            //var B = JsonConvert.SerializeObject(A);
            //var C= Json(B);
            return A;
            
         }
            // GET: api/CarModels/5
            [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCarModel(string id)
        {
            var carModel = await _context.carmodel.FindAsync(id);

            if (carModel == null)
            {
                return NotFound();
            }

            return carModel;
        }

        // PUT: api/CarModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarModel(string id, CarModel carModel)
        {
            if (id != carModel.ModlId)
            {
                return BadRequest();
            }

            _context.Entry(carModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(id))
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

        // POST: api/CarModels
        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
        {
            _context.carmodel.Add(carModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarModel", new { id = carModel.ModlId }, carModel);
        }

        // DELETE: api/CarModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarModel>> DeleteCarModel(string id)
        {
            var carModel = await _context.carmodel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            _context.carmodel.Remove(carModel);
            await _context.SaveChangesAsync();

            return carModel;
        }

        private bool CarModelExists(string id)
        {
            return _context.carmodel.Any(e => e.ModlId == id);
        }
    }
}
