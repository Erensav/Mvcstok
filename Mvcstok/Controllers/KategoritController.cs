using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvcstok.Models.Entity;
namespace Mvcstok.Controllers
{
    public class KategoritController : Controller
    {
        // GET: Kategorit
        MvcdpstokEntities db = new MvcdpstokEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_kategoriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori() 
        {
            return View();   
        }
        [HttpPost]
        public ActionResult YeniKategori(tbl_kategoriler p1) 
        {
            db.tbl_kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori= db.tbl_kategoriler.Find(id);
            db.tbl_kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tbl_kategoriler.Find(id);
            return View("KategoriGetir",ktgr);
        }

    }
}