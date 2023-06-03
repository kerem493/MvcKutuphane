using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {
        // GET: Panelim
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            //var degerler = db.TblUyeler.FirstOrDefault(z => z.mail == uyemail);

            var degerler = db.TblDuyurular.ToList();
            var d1 =db.TblUyeler.Where(x=>x.mail==uyemail).Select(x => x.ad + " " + x.soyad).FirstOrDefault();
            var d2 =db.TblUyeler.Where(x=>x.mail==uyemail).Select(x => x.fotograf).FirstOrDefault();
            var d3 =db.TblUyeler.Where(x=>x.mail==uyemail).Select(x => x.kullaniciadi).FirstOrDefault();
            var d4 =db.TblUyeler.Where(x=>x.mail==uyemail).Select(x => x.okul).FirstOrDefault();
            var d5 =db.TblUyeler.Where(x=>x.mail==uyemail).Select(x => x.telefon).FirstOrDefault();
            var d6 =db.TblUyeler.Where(x=>x.mail==uyemail).Select(x => x.mail).FirstOrDefault();

            var uyeid =db.TblUyeler.Where(x=>x.mail==uyemail).Select(x => x.id).FirstOrDefault();
            var d7 = db.TblHareket.Where(x=>x.uye == uyeid).Count();

            var d8 = db.TblMesajlar.Where(x=>x.alici == uyemail).Count();

            var d9 = db.TblDuyurular.Count();



            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            ViewBag.d5 = d5;
            ViewBag.d6 = d6;
            ViewBag.d7 = d7;
            ViewBag.d8 = d8;
            ViewBag.d9 = d9;


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

        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TblUyeler.Where(x=>x.mail == kullanici.ToString()).Select(z=>z.id).FirstOrDefault();
            var degerler = db.TblHareket.Where(x => x.uye == id).ToList();
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TblDuyurular.ToList();
            return View(duyurulistesi);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TblUyeler.Where(x=>x.mail == kullanici).Select(z=>z.id).FirstOrDefault();
            var uyebul = db.TblUyeler.Find(id);
            return PartialView("Partial2",uyebul);
        }

    }
}