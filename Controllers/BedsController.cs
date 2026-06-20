using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class BedsController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Beds
        public ActionResult Index()
        {
            var beds = db.Beds.Include(b => b.Ward);
            return View(beds.ToList());
        }

        // GET: Beds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bed bed = db.Beds.Find(id);
            if (bed == null)
            {
                return HttpNotFound();
            }
            return View(bed);
        }

        // GET: Beds/Create
        public ActionResult Create()
        {
            ViewBag.WardId = new SelectList(db.Wards, "WardId", "WardName");
            return View();
        }

        // POST: Beds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BedId,BedNumber,IsOccupied,WardId")] Bed bed)
        {
            if (ModelState.IsValid)
            {
                db.Beds.Add(bed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WardId = new SelectList(db.Wards, "WardId", "WardName", bed.WardId);
            return View(bed);
        }

        // GET: Beds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bed bed = db.Beds.Find(id);
            if (bed == null)
            {
                return HttpNotFound();
            }
            ViewBag.WardId = new SelectList(db.Wards, "WardId", "WardName", bed.WardId);
            return View(bed);
        }

        // POST: Beds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BedId,BedNumber,IsOccupied,WardId")] Bed bed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WardId = new SelectList(db.Wards, "WardId", "WardName", bed.WardId);
            return View(bed);
        }

        // GET: Beds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bed bed = db.Beds.Find(id);
            if (bed == null)
            {
                return HttpNotFound();
            }
            return View(bed);
        }

        // POST: Beds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bed bed = db.Beds.Find(id);
            db.Beds.Remove(bed);
            db.SaveChanges();
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
