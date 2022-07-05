using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cldvPOE_st10081893.Models;

namespace cldvPOE_st10081893.Controllers
{
    public class carController : Controller
    {
        private st10081893cldvEntities db = new st10081893cldvEntities();

        // GET: car
        public async Task<ActionResult> Index()
        {
            var tbl_car = db.tbl_car.Include(t => t.tbl_modelInfo);
            return View(await tbl_car.ToListAsync());
        }

        // GET: car/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_car tbl_car = await db.tbl_car.FindAsync(id);
            if (tbl_car == null)
            {
                return HttpNotFound();
            }
            return View(tbl_car);
        }

        // GET: car/Create
        public ActionResult Create()
        {
            ViewBag.modelInfoID = new SelectList(db.tbl_modelInfo, "modelInfoID", "model");
            return View();
        }

        // POST: car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "carID,modelInfoID,available,kilometersTravelled,serviceKilometers")] tbl_car tbl_car)
        {
            if (ModelState.IsValid)
            {
                db.tbl_car.Add(tbl_car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.modelInfoID = new SelectList(db.tbl_modelInfo, "modelInfoID", "model", tbl_car.modelInfoID);
            return View(tbl_car);
        }

        // GET: car/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_car tbl_car = await db.tbl_car.FindAsync(id);
            if (tbl_car == null)
            {
                return HttpNotFound();
            }
            ViewBag.modelInfoID = new SelectList(db.tbl_modelInfo, "modelInfoID", "model", tbl_car.modelInfoID);
            return View(tbl_car);
        }

        // POST: car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "carID,modelInfoID,available,kilometersTravelled,serviceKilometers")] tbl_car tbl_car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.modelInfoID = new SelectList(db.tbl_modelInfo, "modelInfoID", "model", tbl_car.modelInfoID);
            return View(tbl_car);
        }

        // GET: car/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_car tbl_car = await db.tbl_car.FindAsync(id);
            if (tbl_car == null)
            {
                return HttpNotFound();
            }
            return View(tbl_car);
        }

        // POST: car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            tbl_car tbl_car = await db.tbl_car.FindAsync(id);
            db.tbl_car.Remove(tbl_car);
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
