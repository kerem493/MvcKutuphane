using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TblUyeler.FirstOrDefault(z => z.mail == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TblUyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TblUyeler.FirstOrDefault(x=>x.mail == kullanici);
            uye.sifre = p.sifre;
            uye.ad = p.ad;
            uye.soyad = p.soyad;
            uye.fotograf = p.fotograf;
            uye.kullaniciadi = p.kullaniciadi;
            uye.sifre = p.sifre;
            uye.okul = p.okul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TblUyeler.Where(x=>x.mail == kullanici.ToString()).Select(z=>z.id).FirstOrDefault();
            var degerler = db.TblHareket.Where(x => x.uye == id).ToList();
            return View(degerler);
        }

    }
}