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
    public class modelInfoController : Controller
    {
        private st10081893cldvEntities db = new st10081893cldvEntities();

        // GET: modelInfo
        public async Task<ActionResult> Index()
        {
            var tbl_modelInfo = db.tbl_modelInfo.Include(t => t.tbl_bodyType).Include(t => t.tbl_manufacturer);
            return View(await tbl_modelInfo.ToListAsync());
        }

        // GET: modelInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_modelInfo tbl_modelInfo = await db.tbl_modelInfo.FindAsync(id);
            if (tbl_modelInfo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_modelInfo);
        }

        // GET: modelInfo/Create
        public ActionResult Create()
        {
            ViewBag.bodyTypeID = new SelectList(db.tbl_bodyType, "bodyTypeID", "bodyType");
            ViewBag.manufacturerID = new SelectList(db.tbl_manufacturer, "manufacturerID", "manufacturerName");
            return View();
        }

        // POST: modelInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "modelInfoID,manufacturerID,bodyTypeID,model")] tbl_modelInfo tbl_modelInfo)
        {
            if (ModelState.IsValid)
            {
                db.tbl_modelInfo.Add(tbl_modelInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.bodyTypeID = new SelectList(db.tbl_bodyType, "bodyTypeID", "bodyType", tbl_modelInfo.bodyTypeID);
            ViewBag.manufacturerID = new SelectList(db.tbl_manufacturer, "manufacturerID", "manufacturerName", tbl_modelInfo.manufacturerID);
            return View(tbl_modelInfo);
        }

        // GET: modelInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_modelInfo tbl_modelInfo = await db.tbl_modelInfo.FindAsync(id);
            if (tbl_modelInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.bodyTypeID = new SelectList(db.tbl_bodyType, "bodyTypeID", "bodyType", tbl_modelInfo.bodyTypeID);
            ViewBag.manufacturerID = new SelectList(db.tbl_manufacturer, "manufacturerID", "manufacturerName", tbl_modelInfo.manufacturerID);
            return View(tbl_modelInfo);
        }

        // POST: modelInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "modelInfoID,manufacturerID,bodyTypeID,model")] tbl_modelInfo tbl_modelInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_modelInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.bodyTypeID = new SelectList(db.tbl_bodyType, "bodyTypeID", "bodyType", tbl_modelInfo.bodyTypeID);
            ViewBag.manufacturerID = new SelectList(db.tbl_manufacturer, "manufacturerID", "manufacturerName", tbl_modelInfo.manufacturerID);
            return View(tbl_modelInfo);
        }

        // GET: modelInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_modelInfo tbl_modelInfo = await db.tbl_modelInfo.FindAsync(id);
            if (tbl_modelInfo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_modelInfo);
        }

        // POST: modelInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_modelInfo tbl_modelInfo = await db.tbl_modelInfo.FindAsync(id);
            db.tbl_modelInfo.Remove(tbl_modelInfo);
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
