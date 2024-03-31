using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvcstok.Models.Entity;

namespace Mvcstok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcdpstokEntities db = new MvcdpstokEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_musteriler.ToList();
            return View(degerler);
        }
    }
}