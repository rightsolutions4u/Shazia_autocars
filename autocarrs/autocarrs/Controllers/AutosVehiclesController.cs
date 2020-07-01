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
    public class AutosVehiclesController : Controller

    {
       
        private autocarrsContext db = new autocarrsContext();
        

        // GET: AutosVehicles
        public async Task<ActionResult> Index()
        {
            var autosVehicles = db.AutosVehiclesCrollers.Include(a => a.CarBody).Include(a => a.CarCategory).Include(a => a.CarMake).Include(a => a.CarModel);
            return View(await autosVehicles.ToListAsync());
        }

        //GET: AutosVehicles
        [HttpPost]
        public async Task<ActionResult> SearchCars(FormCollection data)
        {
            var qry = "";
            string ABS = data["ABS"];

            Dictionary<string, string> form = data.AllKeys.ToDictionary(k => k, v => data[v]);
            qry = "PowerFrom=" + data["PowerFrom"] + "&PowerTo=" + data["PowerTo"] + "&FromMil=" + data["FromMil"] + "&ToMil=" + data["ToMil"] + "&ABS=" + data["ABS"];
            AutosVehicle autosVehicle = new AutosVehicle();
            var myContent = JsonConvert.SerializeObject(form);

           try
            {
                var data1 = new StringContent( myContent + qry,  Encoding.UTF8, "application/json");
                 var url = "https://localhost:44363/api/AutosVehicles/SearchCars";
                var client = new HttpClient();
                var response = await client.PostAsync(url, data1);
                var AutosSearch = response.Content.ReadAsStringAsync().Result;
                AutosVehicle[] a = JsonConvert.DeserializeObject<AutosVehicle[]>(AutosSearch);
                 ViewBag.AutosVehicle = a;
                return View("MainView", a);
            }
            catch (Exception e)
            {
                Error err = new Error();
                err.ErrorMessage = "Sorry we found no cars with these filters";
                ViewBag.Error = err;
                ViewBag.AutosVehicle = null;
                return View("Error", err);
            }


        }
        [HttpPost]
        public async Task<ActionResult> SearchCars2(FormCollection data)
        {
            string Baseurl = "https://localhost:44363/";
            string Qry = "";
            AutosVehicle autosVehicle = new AutosVehicle();
            if (data["MakeId"] != null)
            {
                Qry = Qry + " and MakeId=" + data["MakeId"];
            }
            if (data["ModelId"] != null)
            {
                Qry = Qry + " and ModlId=" + data["ModelId"];
            }
            if (data["Acolor"] != null)
            {
                Qry = Qry + " and Acolor=" + data["Acolor"];
            }
            if (data["Acolor"] != null)
            {
                Qry = Qry + " and Acolor=" + data["Acolor"];
            }
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                var abc = Request.QueryString["UserId"];
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource PostSiteUsers using HttpClient  
                UriBuilder builder = new UriBuilder("https://localhost:44363/api/SiteUsers/CheckLogin?");
                builder.Query = Qry;
                HttpResponseMessage Res = await client.GetAsync(builder.Uri);
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var searchCars = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    autosVehicle = JsonConvert.DeserializeObject<AutosVehicle>(searchCars);
                    ViewBag.AutosVehicle = autosVehicle;
                    ViewBag.Error = null;
                    return View("MainView", autosVehicle);
                }
                else
                {
                    Error err = new Error();
                    err.ErrorMessage = "Wrong UserId or Password";
                    ViewBag.Error = err;
                    ViewBag.SiteUsers = null;
                    return View("Error", err);
                }
            }

        }
        // GET: AutosVehicles
        [HttpGet]
        public async Task<ActionResult> GetFeaturedAutos()
        {
            AutosVehicle autosVehicle = new AutosVehicle();
            
            try
            {
                var url = "https://localhost:44363/api/AutosVehicles/GetFeatuedAutos";

                var client = new HttpClient();

                var response = await client.GetAsync(url);

                var AutosFeatured = response.Content.ReadAsStringAsync().Result;
                try {
                    AutosVehicle[] a = JsonConvert.DeserializeObject<AutosVehicle[]>(AutosFeatured);
                ViewBag.AutosVehicle = a;
                return View("Featured_cars", a);
                }
                catch {
                    Error err = new Error();
                    err.ErrorMessage = "All our cars are Featured cars";
                    ViewBag.Error = err;
                    ViewBag.AutosVehicle = null;
                    return View("Error", err);
                }
            }
            catch
            {
                Error err = new Error();
                err.ErrorMessage = "All our cars are Featured cars";
                ViewBag.Error = err;
                ViewBag.AutosVehicle = null;
                return View("Error", err);
            }
        }

        // GET: AutosVehicles
        [HttpGet]
        public async Task<ActionResult> SearchCarsBrands(string name)
        {
            AutosVehicle autosVehicle = new AutosVehicle();
           try
            using (var client = new HttpClient())
            {
                //Passing service base url  
               client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource PostSiteUsers using HttpClient  
                UriBuilder builder = new UriBuilder("https://localhost:44363/api/AutosVehicles/SearchCarsBrands?");

                //builder.Query = "id=mars&UserPassword=mars";

                builder.Query = "id=" + name ;
                HttpResponseMessage Res = await client.GetAsync(builder.Uri);
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Brand = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    autosVehicle = JsonConvert.DeserializeObject<AutosVehicle>(Brand);
                    ViewBag.AutosVehicle = autosVehicle;
                    ViewBag.Error = null;
                    return View("MainView", autosVehicle);
                }
                else
                {
                    Error err = new Error();
                    err.ErrorMessage = "Sorry no cars found for"+ name;
                    ViewBag.Error = err;
                    ViewBag.AutosVehicle = null;
                    return View("Error", err);
                }
            }

            }
            }
            catch
            {
                Error err = new Error();
                err.ErrorMessage = "All our cars are Featured cars";
                ViewBag.Error = err;
                ViewBag.AutosVehicle = null;
                return View("Error", err);
            }
        }


        // GET: AutosVehicles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutosVehicle autosVehicle = await db.AutosVehiclesCrollers.FindAsync(id);
            if (autosVehicle == null)
            {
                return HttpNotFound();
            }
            return View(autosVehicle);
        }

        // GET: AutosVehicles/Create
        public ActionResult Create()
        {
            ViewBag.BodyId = new SelectList(db.CarBodies, "BodyId", "BDDesc");
            ViewBag.CatgId = new SelectList(db.CarCategories, "CatgId", "CgDesc");
            ViewBag.MakeId = new SelectList(db.CarMakes, "MakeId", "MkDesc");
            ViewBag.ModlId = new SelectList(db.CarModels, "ModlId", "MdDesc");
            return View();
        }

        // POST: AutosVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AutoId,Acolor,Street,statNm,cityNM,ZipCod,cnName,MILEAG,sellpri,Auyear,transmission,fueltype,power,valume,Engine,Seater,Cosumption,NoOfDoors,IsSold,IsReserved,IsFeataured,IsTrendy,MakeId,ModlId,BodyId,CatgId,sellID")] AutosVehicle autosVehicle)
        {
            if (ModelState.IsValid)
            {
                db.AutosVehiclesCrollers.Add(autosVehicle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BodyId = new SelectList(db.CarBodies, "BodyId", "BDDesc", autosVehicle.BodyId);
            ViewBag.CatgId = new SelectList(db.CarCategories, "CatgId", "CgDesc", autosVehicle.CatgId);
            ViewBag.MakeId = new SelectList(db.CarMakes, "MakeId", "MkDesc", autosVehicle.MakeId);
            ViewBag.ModlId = new SelectList(db.CarModels, "ModlId", "MdDesc", autosVehicle.ModlId);
            return View(autosVehicle);
        }

        // GET: AutosVehicles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutosVehicle autosVehicle = await db.AutosVehiclesCrollers.FindAsync(id);
            if (autosVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BodyId = new SelectList(db.CarBodies, "BodyId", "BDDesc", autosVehicle.BodyId);
            ViewBag.CatgId = new SelectList(db.CarCategories, "CatgId", "CgDesc", autosVehicle.CatgId);
            ViewBag.MakeId = new SelectList(db.CarMakes, "MakeId", "MkDesc", autosVehicle.MakeId);
            ViewBag.ModlId = new SelectList(db.CarModels, "ModlId", "MdDesc", autosVehicle.ModlId);
            return View(autosVehicle);
        }

        // POST: AutosVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AutoId,Acolor,Street,statNm,cityNM,ZipCod,cnName,MILEAG,sellpri,Auyear,transmission,fueltype,power,valume,Engine,Seater,Cosumption,NoOfDoors,IsSold,IsReserved,IsFeataured,IsTrendy,MakeId,ModlId,BodyId,CatgId,sellID")] AutosVehicle autosVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autosVehicle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BodyId = new SelectList(db.CarBodies, "BodyId", "BDDesc", autosVehicle.BodyId);
            ViewBag.CatgId = new SelectList(db.CarCategories, "CatgId", "CgDesc", autosVehicle.CatgId);
            ViewBag.MakeId = new SelectList(db.CarMakes, "MakeId", "MkDesc", autosVehicle.MakeId);
            ViewBag.ModlId = new SelectList(db.CarModels, "ModlId", "MdDesc", autosVehicle.ModlId);
            return View(autosVehicle);
        }

        // GET: AutosVehicles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutosVehicle autosVehicle = await db.AutosVehiclesCrollers.FindAsync(id);
            if (autosVehicle == null)
            {
                return HttpNotFound();
            }
            return View(autosVehicle);
        }

        // POST: AutosVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AutosVehicle autosVehicle = await db.AutosVehiclesCrollers.FindAsync(id);
            db.AutosVehiclesCrollers.Remove(autosVehicle);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
