using IsBulmaProject.Models;
using IsBulmaProject.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace IsBulmaProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IsBulmaEntities model = new IsBulmaEntities();
        [MyAuthorization(Roles = "1")]
        public ActionResult Kategori()
        {
            var kategori = model.IsKategori.ToList();
            ViewBag.Kategori = kategori;    
            return View();
        }
        [HttpGet]
        [MyAuthorization(Roles = "1")]
        public ActionResult KategoriEkle()
        {

            return View();
        }
        [HttpPost]
        [MyAuthorization(Roles = "1")]
        public ActionResult KategoriEkle(IsKategori k)
        {
            model.IsKategori.AddOrUpdate(k);
            model.SaveChanges();
            return RedirectToAction("Kategori");

        }
        [MyAuthorization(Roles = "1")]
        public void KategoriSil(int id)
        {
            var ktg = model.IsKategori.FirstOrDefault(x => x.isKategoriId == id);
            if (ktg != null)
            {
                model.IsKategori.Remove(ktg);
                model.SaveChanges();
            }
            //return RedirectToAction("Ilanlar");
        }
        [HttpGet]
        [MyAuthorization(Roles = "1")]
        public ActionResult KategoriGuncelle(int id)
        {
            var ktg = model.IsKategori.FirstOrDefault(x => x.isKategoriId == id);

            return View(ktg);
        }
        [HttpPost]
        [MyAuthorization(Roles = "1")]
        public ActionResult KategoriGuncelle(IsKategori ktg)
        {
            // Güncellenen kategoriyi veritabanından bulun veya eğer yoksa ekleyin
            model.IsKategori.AddOrUpdate(k => k.isKategoriId, ktg);
            model.SaveChanges();
            return RedirectToAction("Kategori");
        }
    }
}
