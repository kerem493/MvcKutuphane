using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TblAdmin p)
        {
            var bilgiler = db.TblAdmin.FirstOrDefault(x => x.kullanici == p.kullanici && x.sifre == p.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                Session["Kullanici"] = bilgiler.kullanici.ToString();
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}