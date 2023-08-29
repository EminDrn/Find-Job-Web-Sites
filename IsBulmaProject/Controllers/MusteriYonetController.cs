using IsBulmaProject.Models;
using IsBulmaProject.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IsBulmaProject.Controllers
{
    public class MusteriYonetController : Controller
    {
        // GET: Admin
        IsBulmaEntities model = new IsBulmaEntities();
        public ActionResult Kullanici()
        {
            var kullanici = model.Kullanici.ToList();
            ViewBag.Kullanici = kullanici;
            return View();
        }
        [HttpGet]
        [MyAuthorization(Roles = "1")]
        public ActionResult KullaniciEkle()
        {

            return View();
        }
        [HttpPost]
        [MyAuthorization(Roles = "1")]
        public ActionResult KullaniciEkle(Kullanici k)
        {
            model.Kullanici.AddOrUpdate(k);
            model.SaveChanges();
            return RedirectToAction("Kullanici");

        }
        [MyAuthorization(Roles = "1")]
        public void KullaniciSil(int id)
        {
            var ktg = model.Kullanici.FirstOrDefault(x => x.KullaniciID == id);
            if (ktg != null)
            {
                model.Kullanici.Remove(ktg);
                model.SaveChanges();
            }
            //return RedirectToAction("Ilanlar");
        }
        [HttpGet]
        public ActionResult KullaniciGuncelle(int id)
        {
            var ktg = model.Kullanici.FirstOrDefault(x => x.KullaniciID == id);

            return View(ktg);
        }
        [HttpPost]
        public ActionResult KullaniciGuncelle(Kullanici ku)
        {
            model.Kullanici.AddOrUpdate(ku);
            Console.WriteLine(ku.KullaniciID);
            model.SaveChanges();
            if (User.IsInRole("2")){
                return RedirectToAction("KullaniciDetails");

            }
            else
            {
                return RedirectToAction("Kullanici");

            }
        }

        public ActionResult KullaniciDetails(int id)
        {

            var kullanici = model.Kullanici.FirstOrDefault(x => x.KullaniciID == id);

            return View(kullanici);
        }
        [MyAuthorization(Roles = "2")]
        public ActionResult Favori()
        {
            var kullanici = model.Kullanici.FirstOrDefault(x => x.Mail == User.Identity.Name);

            // Kullanıcının tüm favori kayıtlarını al
            List<favori> favoriKayitlari = model.favori.Where(x => x.KullaniciID == kullanici.KullaniciID).ToList();

            // Favori kayıtlarındaki ilanId değerlerini liste olarak çıkar
            List<int> ilanIdListesi = favoriKayitlari.Select(f => f.ilanId).ToList();

            // v_IlanlarByIsVerenId tablosundan ilgili ilanları al
            List<v_IlanlarByIsVerenId> ilanlar = model.v_IlanlarByIsVerenId.Where(x => ilanIdListesi.Contains(x.ilanId)).ToList();

            ViewBag.Kullanici = kullanici;
            ViewBag.Ilanlar = ilanlar;

            return View(ilanlar);

        }
    }
}