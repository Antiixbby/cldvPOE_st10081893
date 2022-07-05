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
    public class rentalController : Controller
    {
        private st10081893cldvEntities db = new st10081893cldvEntities();

        // GET: rental
        public async Task<ActionResult> Index()
        {
            var tbl_rental = db.tbl_rental.Include(t => t.tbl_car).Include(t => t.tbl_driver).Include(t => t.tbl_inspector);
            return View(await tbl_rental.ToListAsync());
        }

        // GET: rental/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_rental tbl_rental = await db.tbl_rental.FindAsync(id);
            if (tbl_rental == null)
            {
                return HttpNotFound();
            }
            return View(tbl_rental);
        }

        // GET: rental/Create
        public ActionResult Create()
        {
            ViewBag.carID = new SelectList(db.tbl_car, "carID", "carID");
            ViewBag.driverID = new SelectList(db.tbl_driver, "driverID", "DriverID");
            ViewBag.inspectorID = new SelectList(db.tbl_inspector, "inspectorID", "inspectorID");
            return View();
        }

        // POST: rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "rentalID,carID,inspectorID,driverID,rentalFee,startDate,endDate")] tbl_rental tbl_rental)
        {
            if (ModelState.IsValid)
            {
                db.tbl_rental.Add(tbl_rental);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.carID = new SelectList(db.tbl_car, "carID", "available", tbl_rental.carID);
            ViewBag.driverID = new SelectList(db.tbl_driver, "driverID", "driverAddress", tbl_rental.driverID);
            ViewBag.inspectorID = new SelectList(db.tbl_inspector, "inspectorID", "inspectorID", tbl_rental.inspectorID);
            return View(tbl_rental);
        }

        // GET: rental/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_rental tbl_rental = await db.tbl_rental.FindAsync(id);
            if (tbl_rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.carID = new SelectList(db.tbl_car, "carID", "carID", tbl_rental.carID);
            ViewBag.driverID = new SelectList(db.tbl_driver, "driverID", "driverID", tbl_rental.driverID);
            ViewBag.inspectorID = new SelectList(db.tbl_inspector, "inspectorID", "inspectorID", tbl_rental.inspectorID);
            return View(tbl_rental);
        }

        // POST: rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "rentalID,carID,inspectorID,driverID,rentalFee,startDate,endDate")] tbl_rental tbl_rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_rental).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.carID = new SelectList(db.tbl_car, "carID", "available", tbl_rental.carID);
            ViewBag.driverID = new SelectList(db.tbl_driver, "driverID", "driverAddress", tbl_rental.driverID);
            ViewBag.inspectorID = new SelectList(db.tbl_inspector, "inspectorID", "inspectorID", tbl_rental.inspectorID);
            return View(tbl_rental);
        }

        // GET: rental/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_rental tbl_rental = await db.tbl_rental.FindAsync(id);
            if (tbl_rental == null)
            {
                return HttpNotFound();
            }
            return View(tbl_rental);
        }

        // POST: rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_rental tbl_rental = await db.tbl_rental.FindAsync(id);
            db.tbl_rental.Remove(tbl_rental);
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
