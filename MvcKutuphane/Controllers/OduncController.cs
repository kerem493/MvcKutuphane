using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            var degerler = db.TblHareket.Where(x => x.islemdurum == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TblUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad + " " + x.soyad,
                                               Value = x.id.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in db.TblKitap.Where(x=>x.durum ==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad,
                                               Value = x.id.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in db.TblPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personel,
                                               Value = x.id.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TblHareket p)
        {
            var d1 = db.TblUyeler.Where(x => x.id == p.TblUyeler.id).FirstOrDefault();
            var d2 = db.TblKitap.Where(x => x.id == p.TblKitap.id).FirstOrDefault();
            var d3 = db.TblPersonel.Where(x => x.id == p.TblPersonel.id).FirstOrDefault();
            p.TblUyeler = d1;
            p.TblKitap = d2;
            p.TblPersonel = d3;
            db.TblHareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Odunciade(TblHareket p)
        {
            var odn = db.TblHareket.Find(p.id);
            DateTime d1 = DateTime.Parse(odn.iadetarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
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