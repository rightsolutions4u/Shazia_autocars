using autocarrs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace autocarrs.Controllers
{
    public class HomeController : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            try {
                Load load = new Load();
                //Load Features
                var client = new HttpClient();
                var url = "https://localhost:44363/api/AutosVehicles/GetFeatuedAutos";
                var response = await client.GetAsync(url);
                var AutosFeatured = response.Content.ReadAsStringAsync().Result;
                load.AutosVehicleF= JsonConvert.DeserializeObject<AutosVehicle[]>(AutosFeatured);
                //CarMake
                var client1 = new HttpClient();
                var url1 = "https://localhost:44363/api/CarMakes/Getcarmake";
                var response1 = await client1.GetAsync(url1);
                var CarMakes = response1.Content.ReadAsStringAsync().Result;
                load.CarMake = JsonConvert.DeserializeObject<CarMake[]>(CarMakes);
                return View("LoadView", load);
            }
            catch (Exception e)
            {
                Error err = new Error();
                err.ErrorMessage = "Sorry couldn't autoload";
                ViewBag.Error = err;
                ViewBag.AutosVehicle = null;
                return View("Error", err);
            }

            
        }
        public PartialViewResult RenderCarMake()
        {
            var CarMake = new CarMakesController();
            return PartialView(CarMake.GetCarMake());
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}