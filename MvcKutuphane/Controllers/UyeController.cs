using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            // var degerler = db.TblUyeler.ToList();
            var degerler = db.TblUyeler.ToList().ToPagedList(sayfa,3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.TblUyeler.Find(id);
            {
                db.TblUyeler.Remove(uye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TblUyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TblUyeler p)
        {
            var uye = db.TblUyeler.Find(p.id);
            uye.ad = p.ad;
            uye.soyad = p.soyad;
            uye.mail = p.mail;
            uye.kullaniciadi = p.kullaniciadi;
            uye.sifre = p.sifre;
            uye.okul = p.okul;
            uye.telefon = p.telefon;
            uye.fotograf = p.fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = db.TblHareket.Where(x => x.uye == id).ToList();
            var uyekit = db.TblUyeler.Where(y => y.id == id).Select(z => z.ad + " " + z.soyad).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgcms);            
        }
    }
}