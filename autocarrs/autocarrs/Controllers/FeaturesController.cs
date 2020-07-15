using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using autocarrs.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Specialized;
using System.Dynamic;
using System.Net.Http.Headers;


namespace autocarrs.Controllers
{
    public class FeaturesController : Controller
    {
        private autocarrsContext db = new autocarrsContext();
        // GET: Features
        public ActionResult Index(FormCollection data)
        {
            //ViewBag.Message = "Welcome to my demo!";
            dynamic mymodel = new ExpandoObject();
            mymodel.AutosVehicle = SearchCars1(data);
            mymodel.AutosFeatures = SearchFeatues(data);
            return View(mymodel);
        }

        [HttpPost]
        public async Task<ActionResult> SearchCars1(FormCollection data)
        {
            Dictionary<string, string> form = data.AllKeys.ToDictionary(k => k, v => data[v]);
            var qry = "PowerFrom=" + data["PowerFrom"] + "&PowerTo=" + data["PowerTo"] + "&FromMil=" + data["FromMil"] + "&ToMil=" + data["ToMil"];
            AutosVehicle autosVehicle = new AutosVehicle();
            var myContent = JsonConvert.SerializeObject(form);

            try
            {
                var data1 = new StringContent(qry + myContent, Encoding.UTF8, "application/json");
                var url = "https://localhost:44363/api/AutosVehicles/SearchCars";
                var client = new HttpClient();
                var response = await client.PostAsync(url, data1);
                var AutosSearch = response.Content.ReadAsStringAsync().Result;
                AutosVehicle[] a = JsonConvert.DeserializeObject<AutosVehicle[]>(AutosSearch);
                ViewBag.AutosVehicle = a;
                return ViewBag.AutosVehicle = a;
            }
            catch (Exception )
            {
                Error err = new Error();
                err.ErrorMessage = "Sorry we found no cars with these filters";
                ViewBag.Error = err;
                ViewBag.AutosVehicle = null;
                return View("Error", err);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SearchFeatues(FormCollection data)
        {
            Dictionary<string, string> form = data.AllKeys.ToDictionary(k => k, v => data[v]);
            var qry = "feID1=" + data["4X41"];//+ "&PowerTo=" + data["PowerTo"] + "&FromMil=" + data["FromMil"] + "&ToMil=" + data["ToMil"];
            AutosFeatuers autosFeatuers = new AutosFeatuers();
            var myContent = JsonConvert.SerializeObject(form);

            try
            {
                var data1 = new StringContent(qry+myContent, Encoding.UTF8, "application/json");
                var url = "https://localhost:44363/api/AutosVehicles/SearchFeatures";
                var client = new HttpClient();
                var response = await client.PostAsync(url, data1);
                var AutosSearch = response.Content.ReadAsStringAsync().Result;
                AutosVehicle[] a = JsonConvert.DeserializeObject<AutosVehicle[]>(AutosSearch);
                ViewBag.AutosSearch = a;
                return ViewBag.AutosSearch = a;
            }
            catch (Exception )
            {
                Error err = new Error();
                err.ErrorMessage = "Sorry we found no cars with these filters";
                ViewBag.Error = err;
                ViewBag.AutosSearch = null;
                return View("Error", err);
            }
        }


    }
}