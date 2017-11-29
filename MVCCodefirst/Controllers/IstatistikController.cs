using MVCCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeFirst.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            //Toplam eğitmen sayısı: 2
            //Son kayıt olan 3 öğrenci
            //Ali
            //Ayşe
            //Mehmet

            //Bu iki bilgiyi (int, List<T>) bir ViewModel tanımlayarak tek paket halinde gönderebiliriz.

            //Models > Ist.cs
            ApplicationDbContext db = new ApplicationDbContext();
            Ist i = new Ist();
            i.Sayi = db.Egitmenler.Count();
            i.Ogrenciler = db.Ogrenciler
                .OrderByDescending(x => x.OgrenciID)
                .Take(3).ToList();
                            
            return View(i);
        }
    }
}