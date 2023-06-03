using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index()
        {
            var kullanicilar = db.TblAdmin.ToList();
            return View(kullanicilar);
        }
        public ActionResult Index2()
        {
            var kullanicilar = db.TblAdmin.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin t)
        {
            db.TblAdmin.Add(t);
            db.SaveChanges();
            return RedirectToAction("index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TblAdmin.Find(id);
            db.TblAdmin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("index2");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TblAdmin.Find(id);
            return View("AdminGuncelle",admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TblAdmin p)
        {
            var admin = db.TblAdmin.Find(p.id);
            admin.kullanici = p.kullanici;
            admin.sifre = p.sifre;
            admin.yetki = p.yetki;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}