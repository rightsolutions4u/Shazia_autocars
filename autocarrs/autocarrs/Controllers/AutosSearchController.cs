using autocarrs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autocarrs.Controllers
{
    public class AutosSearchController : Controller
    {
        // GET: AutosSearch
        public ActionResult Index()
        {
            return View();
        }
        // GET: AutosSearch
        //    [HttpGet]
        //    public ActionResult GetSearch(FormCollection data)
        //    {
        //        AutosSearch autosSearch = new AutosSearch();
        //        AutosVehicle autosVehicle = autosSearch.AutosVehicle;
        //        AutosFeatures autosFeatures = autosSearch.AutosFeatures;

        //        var multipleModels = from V in autosVehicle where V.MakeId = data["Brand"]
        //                             join F in autosFeatures on V.AutosId equals F.AutosId into A
        //                             from F in A.DefaultIfEmpty()
        //                             select new AutosSearch { AutosVehicle = V, AutosFeatures = F };
        //        return View(multipleModels);
        //    }   
        //}
    }
}