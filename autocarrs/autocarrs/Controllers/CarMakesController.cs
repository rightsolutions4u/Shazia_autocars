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
    public class CarMakesController : Controller
    {
        private autocarrsContext db = new autocarrsContext();

        // GET: CarMakes
        public async Task<ActionResult> Index()
        {
            return View(await db.CarMakes.ToListAsync());
        }

        // GET: GetCarMake
        [HttpGet]
        public  async Task<ActionResult> GetCarMake()
        {
            
            CarMake carmake = new CarMake();
            try
            {
                var url = "https://localhost:44363/api/CarMakes/Getcarmake";
                var client = new HttpClient();
                try
                {
                    var response =  await client.GetAsync(url);
                    var CarMakes = response.Content.ReadAsStringAsync().Result;

                    CarMake[] a = JsonConvert.DeserializeObject<CarMake[]>(CarMakes);
                    ViewBag.CarMake = a;
                    return View("RenderCarMake", a);
                    }
                catch (Exception e)
                    {
                    Error err = new Error();
                    err.ErrorMessage = "No Car Brands available";
                    ViewBag.Error = err;
                    ViewBag.CarMake = null;
                    return PartialView("Error", err);
                    }
            }
            catch (Exception )
            {
                Error err = new Error();
                err.ErrorMessage = "No Car Brands available";
                ViewBag.Error = err;
                ViewBag.CarMake = null;
                return View("Error", err);
            }
        }
        // GET: CarMakes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMake carMake = await db.CarMakes.FindAsync(id);
            if (carMake == null)
            {
                return HttpNotFound();
            }
            return View(carMake);
        }

        // GET: CarMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarMakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MakeId,MkDesc")] CarMake carMake)
        {
            if (ModelState.IsValid)
            {
                db.CarMakes.Add(carMake);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(carMake);
        }

        // GET: CarMakes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMake carMake = await db.CarMakes.FindAsync(id);
            if (carMake == null)
            {
                return HttpNotFound();
            }
            return View(carMake);
        }

        // POST: CarMakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MakeId,MkDesc")] CarMake carMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carMake).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(carMake);
        }

        // GET: CarMakes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMake carMake = await db.CarMakes.FindAsync(id);
            if (carMake == null)
            {
                return HttpNotFound();
            }
            return View(carMake);
        }

        // POST: CarMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CarMake carMake = await db.CarMakes.FindAsync(id);
            db.CarMakes.Remove(carMake);
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
