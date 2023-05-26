using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHareket.Where(x=>x.islemdurum== false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TblHareket p)
        {
            db.TblHareket.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Odunciade(int id)
        {
            var odn = db.TblHareket.Find(id);
            return View("Odunciade", odn);
        }
        public ActionResult OduncGuncelle(TblHareket p)
        {
            var hrk = db.TblHareket.Find(p.id);
            hrk.uyegetirtarih = p.uyegetirtarih;
            hrk.islemdurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

   
}