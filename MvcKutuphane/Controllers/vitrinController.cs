using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class vitrinController : Controller
    {
        // GET: vitrin
        DbKütüphaneEntities db = new DbKütüphaneEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TblKitap.ToList();
            cs.Deger2 = db.TblHakkimizda.ToList();
            var degerler = db.TblKitap.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(Tbliletisim t)
        {
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}