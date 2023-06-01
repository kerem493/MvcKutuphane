using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TblUyeler p)
        {
            var bilgiler = db.TblUyeler.FirstOrDefault(x => x.mail == p.mail && x.sifre == p.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.mail, false);
                Session["Mail"] = bilgiler.mail.ToString();
                //TempData["id"] = bilgiler.id.ToString();
                //TempData["Ad"] = bilgiler.ad.ToString();
                //TempData["Soyad"] = bilgiler.soyad.ToString();
                //TempData["Kullanıcı Adı"] = bilgiler.kullaniciadi.ToString();
                //TempData["Şifre"] = bilgiler.sifre.ToString();
                //TempData["Okul"] = bilgiler.okul.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}