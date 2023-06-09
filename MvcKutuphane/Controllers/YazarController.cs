﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblYazar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        public ActionResult YazarEkle(TblYazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TblYazar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.TblYazar.Find(id);
            db.TblYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TblYazar.Find(id);
            return View("YazarGetir",yzr);
        }

        public ActionResult YazarGuncelle(TblYazar p)
        {
            var yzr = db.TblYazar.Find(p.id);
            yzr.ad = p.ad;
            yzr.soyad = p.soyad;
            yzr.detay = p.detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TblKitap.Where(x=>x.yazar == id).ToList();
            var yzrad = db.TblYazar.Where(y=>y.id==id).Select(z=>z.ad + " " + z.soyad).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(yazar);
        }
    }
}