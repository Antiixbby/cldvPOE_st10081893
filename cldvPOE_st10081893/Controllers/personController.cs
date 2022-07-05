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
    public class personController : Controller
    {
        private st10081893cldvEntities db = new st10081893cldvEntities();

        // GET: person
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_person.ToListAsync());
        }

        // GET: person/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_person tbl_person = await db.tbl_person.FindAsync(id);
            if (tbl_person == null)
            {
                return HttpNotFound();
            }
            return View(tbl_person);
        }

        // GET: person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "personID,personName,emailAddr,mobile")] tbl_person tbl_person)
        {
            if (ModelState.IsValid)
            {
                db.tbl_person.Add(tbl_person);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_person);
        }

        // GET: person/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_person tbl_person = await db.tbl_person.FindAsync(id);
            if (tbl_person == null)
            {
                return HttpNotFound();
            }
            return View(tbl_person);
        }

        // POST: person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "personID,personName,emailAddr,mobile")] tbl_person tbl_person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_person).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_person);
        }

        // GET: person/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_person tbl_person = await db.tbl_person.FindAsync(id);
            if (tbl_person == null)
            {
                return HttpNotFound();
            }
            return View(tbl_person);
        }

        // POST: person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_person tbl_person = await db.tbl_person.FindAsync(id);
            db.tbl_person.Remove(tbl_person);
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
