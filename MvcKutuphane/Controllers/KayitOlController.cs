using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
       
    }
}