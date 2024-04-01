using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvcstok.Models.Entity;

namespace Mvcstok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcdpstokEntities db = new MvcdpstokEntities();
        public ActionResult Index()
        {
            var degerler =db.tbl_urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun() 
        {
            List<SelectListItem> degerler=(from i in db.tbl_kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.kategoriad,
                                               Value = i.kategoriid.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;


            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(tbl_urunler p1)
        {
            var ktg=db.tbl_kategoriler.Where(m => m.kategoriid == p1.tbl_kategoriler.kategoriid).FirstOrDefault();
            p1.tbl_kategoriler = ktg;
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}