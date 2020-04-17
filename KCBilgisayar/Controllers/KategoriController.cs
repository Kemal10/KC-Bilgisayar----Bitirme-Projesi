using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KCBilgisayar.Models.Entity;

namespace KCBilgisayar.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Computer_HardwareEntities db = new Computer_HardwareEntities();

        public ActionResult Index()
        {
            var degerler = db.Kategori_Tbl.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori (Kategori_Tbl p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Kategori_Tbl.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil (int id)
        {
            var kategori = db.Kategori_Tbl.Find(id);
            db.Kategori_Tbl.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Kategori_Tbl.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(Kategori_Tbl p1)
        {
            var ktg = db.Kategori_Tbl.Find(p1.Kategori_Id);
            ktg.Kategori_Ad = p1.Kategori_Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}