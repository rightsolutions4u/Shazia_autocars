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
    public class AutosSearchController : ControllerBase
    {
        private readonly SiteContext _context;

        public AutosSearchController(SiteContext context)
        {
            _context = context;
        }
        // GET: api/AutosSearch
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
       // GET: api/AutosSearch
    //   [HttpGet]
    //    public ActionResult SearchCars(AutosSearch autosSearch, AutosVehicle autosVehicle)
        
    //    {

    //        var query = _context.AutosVehicle
    //     .Join(
    //    _context.AutosFeatures,
    //    AutosVehicle => AutosVehicle.AutoId,
    //    AutosFeatures => AutosFeatures.AutoId,
    //    (AutosVehicle, AutosFeatures) => new
    //    {
    //        AutosID = AutosVehicle.AutoId,
    //        CustomerName = customer.FirstName + "" + customer.LastName,
    //        InvoiceDate = invoice.Date
    //}
    //).ToList();
    ////var  a = _context.AutosSearch.FromSql("SELECT * from AutosVehicle").ToList();


    //        return query;
    //    }


    }
}
