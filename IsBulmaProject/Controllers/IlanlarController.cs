using IsBulmaProject.Models;
using IsBulmaProject.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IsBulmaProject.Controllers
{
    public class IlanlarController : Controller
    {
        IsBulmaEntities model = new IsBulmaEntities();


        public ActionResult Index(int? id)
        {
            List<IsKategori> kategori = model.IsKategori.ToList();
            List<IlanPozisyonSeviye> kategoriBySeviye = model.IlanPozisyonSeviye.ToList();
            ViewBag.Kategori = kategori;
            ViewBag.KategoriBySeviye = kategoriBySeviye;
            ViewBag.SelectedCategory = RouteData?.Values["id"];
            ViewBag.SelcetedCategoryBySeviye = RouteData?.Values["id"];


            List<v_IlanlarByIsVerenId> l = model.v_IlanlarByIsVerenId.ToList();
            List<v_IlanlarByIsVerenId> tmp;
            if (id != null)
            {
                tmp = l.Where(i => i.isKategoriId == id).ToList();
                // l = l.Where(i=>i.PozisyonSeviyeId == id).ToList();
                if (tmp.Count < 1)
                {
                    tmp = l.Where(i => i.PozisyonSeviyeId == id).ToList();
                }
                l = tmp;
            }

            return View(l);
        }
        //[Authorize(Roles("Sirket")]
        //[Authorize(Roles = "Employer")]
        public ActionResult Details(int id)
        {
            var ilan = model.v_IlanlarByIsVerenId.FirstOrDefault(i => i.ilanId == id);

            if (ilan == null)
            {
                return HttpNotFound();
            }
            // ilanin tüm basvuru kayıtlarını al
            List<v_KullaniciBasvurular> basvuruKayitlari = model.v_KullaniciBasvurular.Where(x => x.ilanId == id).ToList();

            // Favori kayıtlarındaki ilanId değerlerini liste olarak çıkar
            //List<int> KullaniciIdListesi = basvuruKayitlari.Select(f => f.KullaniciID).ToList();

            //// v_IlanlarByIsVerenId tablosundan ilgili ilanları al
            //List<v_KullaniciBasvurular> kullanicilar = model.v_KullaniciBasvurular.Where(x => KullaniciIdListesi.Contains(x.KullaniciID)).ToList();
            ViewBag.Kullanicilar = basvuruKayitlari;
            return View(ilan);
        }
        [MyAuthorization(Roles = "2")]
        public ActionResult FavoriEkle(int id)
        {
            var kullanici = model.Kullanici.FirstOrDefault(x => x.Mail == User.Identity.Name);
            var ilan = model.Ilan.FirstOrDefault(x => x.ilanId == id);
            var favori = new favori
            {
                KullaniciID = kullanici.KullaniciID,
                ilanId = ilan.ilanId
            };

            // Favoriyi veritabanına ekle
            model.favori.AddOrUpdate(favori);
            model.SaveChanges();
            return RedirectToAction("Details", new { id = ilan.ilanId });
        }
        [HttpGet]
        [MyAuthorization(Roles = "2")]
        public ActionResult Basvur(int id)
        {
            var ilan = model.Ilan.FirstOrDefault(x => x.ilanId == id);
            return View(ilan);
        }
        [HttpPost]
        [MyAuthorization(Roles = "2")]
        public ActionResult Basvur(System.Web.HttpPostedFileBase yuklenecekDosya, FormCollection formCollection)
        {
            int ilanId = Convert.ToInt32(formCollection["ilanId"]);

            if (yuklenecekDosya != null)
            {
                string dosyaAdi = Path.GetFileName(yuklenecekDosya.FileName);
                string dosyaYolu = Path.Combine(Server.MapPath("~/Dosyalar"), dosyaAdi);
                yuklenecekDosya.SaveAs(dosyaYolu);

                var kullanici = model.Kullanici.FirstOrDefault(x => x.Mail == User.Identity.Name);

                var existingBasvur = model.Basvuru.FirstOrDefault(b => b.ilanId == ilanId && b.KullaniciID == kullanici.KullaniciID);
                if (existingBasvur != null)
                {
                    existingBasvur.CVdosyaPath = dosyaAdi;
                }
                else
                {
                    Basvuru basvur = new Basvuru();
                    basvur.ilanId = ilanId;
                    basvur.CVdosyaPath = dosyaAdi;
                    basvur.KullaniciID = kullanici.KullaniciID;
                    model.Basvuru.Add(basvur);
                }
                var ilan = model.Ilan.FirstOrDefault(x => x.ilanId == ilanId);
                ilan.ilanBasvuruSayisi++;
                model.Ilan.AddOrUpdate(ilan);
                model.SaveChanges();
            }

            return RedirectToAction("Details", new { id = ilanId });
        }
    }
}