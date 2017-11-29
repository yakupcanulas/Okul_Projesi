using MVCCodefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodefirst.Controllers
{
    public class AdminEgitmenController : Controller
    {
        // GET: AdminEgitmen
        public ActionResult Index()
        {
            return View(db.Egitmenler.ToList());
        }
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include ="EgitmenID,AdSoyad,DogumTarihi")] Egitmen egitmen)
        {
            if (ModelState.IsValid)
            {
                db.Egitmenler.Add(egitmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(egitmen);

        }


        public ActionResult Edit()
        {

            return View();

        }
    }
}