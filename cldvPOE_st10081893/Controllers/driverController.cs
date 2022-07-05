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
    public class driverController : Controller
    {
        private st10081893cldvEntities db = new st10081893cldvEntities();

        // GET: driver
        public async Task<ActionResult> Index()
        {
            var tbl_driver = db.tbl_driver.Include(t => t.tbl_person);
            return View(await tbl_driver.ToListAsync());
        }

        // GET: driver/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_driver tbl_driver = await db.tbl_driver.FindAsync(id);
            if (tbl_driver == null)
            {
                return HttpNotFound();
            }
            return View(tbl_driver);
        }

        // GET: driver/Create
        public ActionResult Create()
        {
            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName");
            return View();
        }

        // POST: driver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "driverID,personID,driverAddress")] tbl_driver tbl_driver)
        {
            if (ModelState.IsValid)
            {
                db.tbl_driver.Add(tbl_driver);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName", tbl_driver.personID);
            return View(tbl_driver);
        }

        // GET: driver/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_driver tbl_driver = await db.tbl_driver.FindAsync(id);
            if (tbl_driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName", tbl_driver.personID);
            return View(tbl_driver);
        }

        // POST: driver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "driverID,personID,driverAddress")] tbl_driver tbl_driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_driver).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName", tbl_driver.personID);
            return View(tbl_driver);
        }

        // GET: driver/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_driver tbl_driver = await db.tbl_driver.FindAsync(id);
            if (tbl_driver == null)
            {
                return HttpNotFound();
            }
            return View(tbl_driver);
        }

        // POST: driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_driver tbl_driver = await db.tbl_driver.FindAsync(id);
            db.tbl_driver.Remove(tbl_driver);
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
