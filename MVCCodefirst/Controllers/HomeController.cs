using MVCCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Ogrenci> liste = db.Ogrenciler.ToList();
            return View(liste);
        }

        //GET: /Home/Dersler
        public ActionResult Dersler()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return View(db.Dersler.ToList());
        }

        public ActionResult Egitmenler()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return View(db.Egitmenler.ToList());
        }
        
        public ActionResult TekDers2()
        {
            Ders ders = new Ders();
            ders.DersAdi = "Matematik";
            ders.Aciklama = "Lineer Cebir";
            return View(ders);
        }

        public ActionResult TekDers(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return View(db.Dersler.Find(id));
        }

        public ActionResult EgitmenDetay(int? id)
        {
            if(id == null)
            {
                HttpContext.Response.StatusCode = 404;
                HttpContext.Response.End();
                //veya
                // ViewBag.Hata = "Bu sayfayı çağırabilmek için id parametresini gönderin";
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var e = db.Egitmenler.Find(id);
                if(e == null)
                {
                    ViewBag.Hata = "Aradığınız eğitmen bulunamadı.";
                }
                else
                {
                    return View(e);
                }
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}