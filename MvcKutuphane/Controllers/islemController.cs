using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class islemController : Controller
    {
        // GET: islem
        DbKütüphaneEntities db = new DbKütüphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHareket.Where(x => x.islemdurum == true).ToList();
            return View(degerler);
        }
    }
}