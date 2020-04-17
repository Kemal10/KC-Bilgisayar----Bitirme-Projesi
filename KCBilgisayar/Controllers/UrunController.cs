using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCBilgisayar.Models.Entity;

namespace KCBilgisayar.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Computer_HardwareEntities db = new Computer_HardwareEntities();
        public ActionResult Index()
        {
            var deger = db.Urunler_Tbl.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategori_Tbl.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategori_Ad,
                                                 Value = i.Kategori_Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunler_Tbl p1)
        {
            var ktg = db.Kategori_Tbl.Where(m => m.Kategori_Id == p1.Kategori_Tbl.Kategori_Id).FirstOrDefault();
            p1.Kategori_Tbl = ktg;
    
            db.Urunler_Tbl.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = db.Urunler_Tbl.Find(id);
            db.Urunler_Tbl.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urunler_Tbl.Find(id);
            List<SelectListItem> degerler = (from i in db.Kategori_Tbl.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategori_Ad,
                                                 Value = i.Kategori_Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir",urun);
        }
        public ActionResult Guncelle(Urunler_Tbl p)
        {
            var urun = db.Urunler_Tbl.Find(p.UrunID);
            urun.UrunAd = p.UrunAd;
            //urun.UrunKategori = p.UrunKategori;
            var ktg = db.Kategori_Tbl.Where(m => m.Kategori_Id == p.Kategori_Tbl.Kategori_Id).FirstOrDefault();
            urun.UrunKategori = ktg.Kategori_Id;
            urun.Fiyat = p.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}