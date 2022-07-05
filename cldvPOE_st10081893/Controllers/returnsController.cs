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
    public class returnsController : Controller
    {
        private st10081893cldvEntities db = new st10081893cldvEntities();

        // GET: returns
        public async Task<ActionResult> Index()
        {
            var tbl_returns = db.tbl_returns.Include(t => t.tbl_rental);
            return View(await tbl_returns.ToListAsync());
        }

        // GET: returns/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_returns tbl_returns = await db.tbl_returns.FindAsync(id);
            if (tbl_returns == null)
            {
                return HttpNotFound();
            }
            return View(tbl_returns);
        }

        // GET: returns/Create
        public ActionResult Create()
        {
            ViewBag.rentalID = new SelectList(db.tbl_rental, "rentalID", "carID");
            return View();
        }

        // POST: returns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "returnID,rentalID,returnDate,elapsedDate,fine")] tbl_returns tbl_returns)
        {
            if (ModelState.IsValid)
            {
                db.tbl_returns.Add(tbl_returns);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.rentalID = new SelectList(db.tbl_rental, "rentalID", "carID", tbl_returns.rentalID);
            return View(tbl_returns);
        }

        // GET: returns/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_returns tbl_returns = await db.tbl_returns.FindAsync(id);
            if (tbl_returns == null)
            {
                return HttpNotFound();
            }
            ViewBag.rentalID = new SelectList(db.tbl_rental, "rentalID", "carID", tbl_returns.rentalID);
            return View(tbl_returns);
        }

        // POST: returns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "returnID,rentalID,returnDate,elapsedDate,fine")] tbl_returns tbl_returns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_returns).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.rentalID = new SelectList(db.tbl_rental, "rentalID", "carID", tbl_returns.rentalID);
            return View(tbl_returns);
        }

        // GET: returns/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_returns tbl_returns = await db.tbl_returns.FindAsync(id);
            if (tbl_returns == null)
            {
                return HttpNotFound();
            }
            return View(tbl_returns);
        }

        // POST: returns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_returns tbl_returns = await db.tbl_returns.FindAsync(id);
            db.tbl_returns.Remove(tbl_returns);
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
