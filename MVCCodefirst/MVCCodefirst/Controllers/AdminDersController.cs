using MVCCodefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodefirst.Controllers
{
    public class AdminDersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdminDers
        public ActionResult Index()
        {
            return View(db.Dersler.ToList());


        }

        public ActionResult Delete()
        {
            return View();
        }

        //Get işlemi için
        public ActionResult Create()
        {
            return View();
        }

        //post işlemi için

            [HttpPost]
            [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="DersID,DersAdi,Aciklama")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                
                db.Dersler.Add(ders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(ders);

        }
    }
}