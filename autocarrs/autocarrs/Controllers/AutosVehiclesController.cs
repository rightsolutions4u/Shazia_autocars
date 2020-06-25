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

namespace autocarrs.Controllers
{
    public class AutosVehiclesController : Controller

    {
       
        private autocarrsContext db = new autocarrsContext();
        private AutosVehicle[] a;

        // GET: AutosVehicles
        public async Task<ActionResult> Index()
        {
            var autosVehicles = db.AutosVehicles.Include(a => a.CarBody).Include(a => a.CarCategory).Include(a => a.CarMake).Include(a => a.CarModel);
            return View(await autosVehicles.ToListAsync());
        }

        // GET: AutosVehicles
        //public async Task<ActionResult> GetAutosWithImages()
        //{
        //    //var autosVehicles = db.AutosVehicles.Include(a => a.CarBody).Include(a => a.CarCategory).Include(a => a.CarMake).Include(a => a.CarModel);
        //    var viewModel = new AutosWithImages();
        //    viewModel.AutosVehicle = db.AutosVehicles
        //        .Include(a => a.CarBody)
        //        .Include(a => a.CarCategory)
        //        .Include(a => a.CarMake)
        //        .Include(a => a.CarModel);
        //    viewModel.AutosImages= viewModel.AutosVehicle.Where
        //        (a => a.AutoId /*== id.Value*/).Single().AutosImages;
        //    ;


        //    return View(await viewModel.ToListAsync());
        //}
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
                err.ErrorMessage = "Wrong UserId or Password";
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
            AutosVehicle autosVehicle = await db.AutosVehicles.FindAsync(id);
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
                db.AutosVehicles.Add(autosVehicle);
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
            AutosVehicle autosVehicle = await db.AutosVehicles.FindAsync(id);
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
            AutosVehicle autosVehicle = await db.AutosVehicles.FindAsync(id);
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
            AutosVehicle autosVehicle = await db.AutosVehicles.FindAsync(id);
            db.AutosVehicles.Remove(autosVehicle);
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
