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

namespace autocarrs.Controllers
{
    public class AutosImagesController : Controller
    {
        private autocarrsContext db = new autocarrsContext();

        // GET: AutosImages
        public async Task<ActionResult> Index()
        {
            return View(await db.AutosImages.ToListAsync());
        }

        // GET: AutosImages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutosImages autosImages = await db.AutosImages.FindAsync(id);
            if (autosImages == null)
            {
                return HttpNotFound();
            }
            return View(autosImages);
        }

        // GET: AutosImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutosImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ImageID,AutosID,ImgURL")] AutosImages autosImages)
        {
            if (ModelState.IsValid)
            {
                db.AutosImages.Add(autosImages);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(autosImages);
        }

        // GET: AutosImages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutosImages autosImages = await db.AutosImages.FindAsync(id);
            if (autosImages == null)
            {
                return HttpNotFound();
            }
            return View(autosImages);
        }

        // POST: AutosImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ImageID,AutosID,ImgURL")] AutosImages autosImages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autosImages).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(autosImages);
        }

        // GET: AutosImages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutosImages autosImages = await db.AutosImages.FindAsync(id);
            if (autosImages == null)
            {
                return HttpNotFound();
            }
            return View(autosImages);
        }

        // POST: AutosImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AutosImages autosImages = await db.AutosImages.FindAsync(id);
            db.AutosImages.Remove(autosImages);
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
