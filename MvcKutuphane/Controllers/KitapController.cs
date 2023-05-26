using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap

        DbKütüphaneEntities db = new DbKütüphaneEntities();

        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TblKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m=>m.ad.Contains(p));
            }
            // var kitaplar = db.TblKitap.ToList();
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;     // ViewBag değeri taşımak için kullanılır. deger1 verisini dgr1 olarak çağırmak için kullanıldı.
                                       // KitapEkle.cshtml dosyası kategori ekle kısmında çağırıldı.

            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad + ' ' + i.soyad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TblKitap p)
        {
            var ktg = db.TblKategori.Where(k => k.id == p.TblKategori.id).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.id == p.TblYazar.id).FirstOrDefault();
            p.TblKategori = ktg;
            p.TblYazar = yzr;
            db.TblKitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TblKitap.Find(id);
            db.TblKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TblKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad + ' ' + i.soyad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("KitapGetir", ktp);
        }

        public ActionResult KitapGuncelle(TblKitap p)
        {
            var kitap = db.TblKitap.Find(p.id);
            kitap.ad = p.ad;
            kitap.basımyil = p.basımyil;
            kitap.sayfa = p.sayfa;
            kitap.yayinevi = p.yayinevi;
            kitap.durum = true;
            var ktg = db.TblKategori.Where(k=>k.id==p.TblKategori.id).FirstOrDefault();
            var yzr = db.TblYazar.Where(y=>y.id==p.TblYazar.id).FirstOrDefault();
            kitap.kategori = ktg.id;
            kitap.yazar = yzr.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}