﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCodeFirst.Models;

namespace MVCCodeFirst.Controllers
{
    public class AdminDersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminDers
        public ActionResult Index()
        {
            return View(db.Dersler.ToList());
        }

        // GET: AdminDers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Dersler.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // GET: AdminDers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminDers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DersID,DersAdi,Aciklama")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Dersler.Add(ders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ders);
        }

        // GET: AdminDers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Dersler.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // POST: AdminDers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DersID,DersAdi,Aciklama")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ders);
        }

        // GET: AdminDers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Dersler.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // POST: AdminDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ders ders = db.Dersler.Find(id);
            db.Dersler.Remove(ders);
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
