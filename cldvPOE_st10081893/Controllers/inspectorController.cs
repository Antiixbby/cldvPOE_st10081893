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
    public class inspectorController : Controller
    {
        private st10081893cldvEntities db = new st10081893cldvEntities();

        // GET: inspector
        public async Task<ActionResult> Index()
        {
            var tbl_inspector = db.tbl_inspector.Include(t => t.tbl_person);
            return View(await tbl_inspector.ToListAsync());
        }

        // GET: inspector/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inspector tbl_inspector = await db.tbl_inspector.FindAsync(id);
            if (tbl_inspector == null)
            {
                return HttpNotFound();
            }
            return View(tbl_inspector);
        }

        // GET: inspector/Create
        public ActionResult Create()
        {
            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName");
            return View();
        }

        // POST: inspector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "inspectorID,personID")] tbl_inspector tbl_inspector)
        {
            if (ModelState.IsValid)
            {
                db.tbl_inspector.Add(tbl_inspector);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName", tbl_inspector.personID);
            return View(tbl_inspector);
        }

        // GET: inspector/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inspector tbl_inspector = await db.tbl_inspector.FindAsync(id);
            if (tbl_inspector == null)
            {
                return HttpNotFound();
            }
            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName", tbl_inspector.personID);
            return View(tbl_inspector);
        }

        // POST: inspector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "inspectorID,personID")] tbl_inspector tbl_inspector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_inspector).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.personID = new SelectList(db.tbl_person, "personID", "personName", tbl_inspector.personID);
            return View(tbl_inspector);
        }

        // GET: inspector/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inspector tbl_inspector = await db.tbl_inspector.FindAsync(id);
            if (tbl_inspector == null)
            {
                return HttpNotFound();
            }
            return View(tbl_inspector);
        }

        // POST: inspector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_inspector tbl_inspector = await db.tbl_inspector.FindAsync(id);
            db.tbl_inspector.Remove(tbl_inspector);
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
