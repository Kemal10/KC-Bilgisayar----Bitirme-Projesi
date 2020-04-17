using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCBilgisayar.Models.Entity;

namespace KCBilgisayar.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        Computer_HardwareEntities db = new Computer_HardwareEntities();

        public ActionResult Index()
        {
            var degerler = db.Musteriler_Tbl.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Musteriler_Tbl p1)
        {
            db.Musteriler_Tbl.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var musteri = db.Musteriler_Tbl.Find(id);
            db.Musteriler_Tbl.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var must = db.Musteriler_Tbl.Find(id);

            return View("MusteriGetir", must);
        }
        public ActionResult Guncelle(Musteriler_Tbl p1)
        {
            var musteri = db.Musteriler_Tbl.Find(p1.Musteri_Id);
            musteri.Musteri_Ad = p1.Musteri_Ad;
            musteri.Musteri_Soyad = p1.Musteri_Soyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}