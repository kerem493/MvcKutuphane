using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblDuyurular.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(TblDuyurular t)
        {
            db.TblDuyurular.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TblDuyurular.Find(id);
            db.TblDuyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DuyuruDetay(TblDuyurular d)
        {
            var dyr = db.TblDuyurular.Find(d.id);
            return View("DuyuruDetay",dyr);
        }

        public ActionResult DuyuruGuncelle(TblDuyurular t) // güncelle butonuna basınca birşey olmuyor!!!
        {
            var dyr = db.TblDuyurular.Find(t.id);
            dyr.kategori = t.kategori;
            dyr.icerik = t.icerik;
            dyr.tarih = t.tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}