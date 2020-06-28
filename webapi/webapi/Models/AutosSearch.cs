using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class AutosSearch //is based on 2 models
    {
        [Key]
        public int AutoId { get; set; }
        public AutosVehicle AutosVehicle { get; set; }
        public AutosFeatures AutosFeatures { get; set; }

    }


    //public ActionResult<List<ExtendedAutosVehicle>> SearchCars(string Sql)
    //{
    //    ExtendedAutosVehicle AV = new ExtendedAutosVehicle();
    //    //Please right code here to send sql with where clause
    //    var authorId = new SqlParameter("@whereclause", " and Acolor in ('Silver', 'Gold')");
    //    var books = _context.AutosVehicle
    //        .FromSqlRaw("EXEC GetAutosVehicles @whereclause", authorId)
    //        .ToList();
    //}
}
