using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;
using Microsoft.EntityFrameworkCore;


namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtendedAutosVehiclesController : ControllerBase
    {
        private readonly SiteContext _context;

        public ExtendedAutosVehiclesController(SiteContext context)
        {
            _context = context;
        }

        //// GET: api/AutosVehicles
        //[HttpGet("SearchCars")]
        //public ActionResult<List<ExtendedAutosVehicle>> SearchCars(string Sql)
        //{
        //    ExtendedAutosVehicle AV = new ExtendedAutosVehicle();
        //    //Please right code here to send sql with where clause
        //    var authorId = new SqlParameter("@whereclause", " and Acolor in ('Silver', 'Gold')");
        //    var books = _context.AutosVehicle
        //        //.FromSql("select * from AutoImages")
        //        .FromSql("EXEC GetAutosVehicles @whereclause", authorId)
        //        .ToList();
        //    return (books);
        //    //you can call ctx.Database.GetDbConnection() on your DbContext to get a plain old ADO DbConnection, construct commands and execute them.
        //}
        //public HttpActionResult GetAllTables()
        //{
        //    ExtendedAutosVehicle ext = new ExtendedAutosVehicle();

        //    AutosVehicle autosVehicle = ext.GetAutosVehicle;
        //    AutosImages autosImages = ext.GetAutosImages;

        //    var multipleModels = from V in autosVehicle
        //                         join F in autosImages on V.AutosId equals F.AutosId into A
        //                         from F in A.DefaultIfEmpty()
        //                         select new ExtendedAutosVehicle { GetAutosVehicle = V, GetAutosImages = F };
        //    return (multipleModels);

        //            }


    }
}
