using autocarrs.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace autocarrs.Controllers
{
    public class HomeController : Controller
    {

        //public ActionResult Index()
        //{

        //    return View();

        //}


        public async Task<ActionResult> Index()
        {
            AutosVehicle autosVehicle = new AutosVehicle();
            var client = new HttpClient();
            var url = "https://localhost:44363/api/AutosVehicles/GetFeatuedAutos";

            var response = await client.GetAsync(url);

            var AutosFeatured = response.Content.ReadAsStringAsync().Result;
            try
            {
                AutosVehicle[] a = JsonConvert.DeserializeObject<AutosVehicle[]>(AutosFeatured);
                ViewBag.AutosVehicle = a;
                return View("Featured_cars", a);
            }
            catch
            {

            }

            return View();
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