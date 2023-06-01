using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.alici == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.gonderen == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar t)
        {
          var uyemail = (string)Session["Mail"].ToString();
            t.gonderen =uyemail.ToString();
            t.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesajlar.Add(t);
            db.SaveChanges();
            return RedirectToAction("giden","mesajlar");
        }
    }
}