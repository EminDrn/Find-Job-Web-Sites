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
    public class SirketIlanlarController : Controller
    {
        IsBulmaEntities model = new IsBulmaEntities();
        
        // GET: Ilanlar

        //[Route("Default-2")]
        [AllowAnonymous]
        

        public ActionResult Ilanlar(int? id)
        {
            List<IsKategori> kategori = model.IsKategori.ToList();

            List<IlanPozisyonSeviye> kategoriBySeviye = model.IlanPozisyonSeviye.ToList();
            ViewBag.Kategori = kategori;
            ViewBag.KategoriBySeviye = kategoriBySeviye;
            ViewBag.SelectedCategory = RouteData?.Values["id"];
            ViewBag.SelcetedCategoryBySeviye = RouteData?.Values["id"];
            string isverenAdi = HttpContext.User.Identity.Name;

            List<v_IlanlarByIsVerenId> l = model.v_IlanlarByIsVerenId.Where(x => x.isVerenSirketAdi == isverenAdi).ToList();
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
        [HttpGet]
        [MyAuthorization(Roles = "3")]
        public ActionResult IlanEkle()
        {
            List<IsKategori> kategori = model.IsKategori.ToList();
            List<IlanPozisyonSeviye> seviye = model.IlanPozisyonSeviye.ToList();
            ViewBag.CurrentUserId = HttpContext.User.Identity.Name;
            ViewBag.Kategoriler = kategori;
            ViewBag.ilanSeviye = seviye;

            return View();
        }
        [HttpPost]
        [MyAuthorization(Roles = "3")]
        public ActionResult IlanEkle(Ilan model1)
        {
            string isverenadi = HttpContext.User.Identity.Name;
            var id = model.IsVerenKayit.FirstOrDefault(i => i.isVerenSirketAdi == isverenadi);
            model1.isVerenId = id.isVerenId;

            //string tanitim = model1.ilanTanitimId.ToString();

            //model.IlanTanitim.Add(tanitim);
            //model.IlanTanitim.AddOrUpdate(tanitim);

            //var tnt = model.IlanTanitim.FirstOrDefault(i => i.ilanOzet == tanitim);
            model1.ilanBasvuruSayisi = 0;
            model1.IlanEklenmeTarihi = DateTime.UtcNow;
            model.Ilan.AddOrUpdate(model1);
            model.SaveChanges();
            return RedirectToAction("Ilanlar");
            //string pozisyonAdi = model1.PozisyonSeviyeId.ToString(); // Diyelim ki model1.PozisyonSeviyeId string olarak gelir

            //var pozisyon = model.IlanPozisyonSeviye.FirstOrDefault(x => x.PozisyonSeviyeAdi == pozisyonAdi);

            //if (pozisyon != null)
            //{
            //    int pozisyonId = pozisyon.SeviyeId;

            //    // Şimdi pozisyonId değerini model1 nesnesine atayabilirsiniz
            //    model1.PozisyonSeviyeId = pozisyonId;

            //    model.Ilan.AddOrUpdate(model1);
            //    model.SaveChanges();
            //    return RedirectToAction("Ilanlar");
            //}
            //return RedirectToAction("IlanEkle");
            //string kullaniciMail = HttpContext.User.Identity.Name; // Kullanıcının mail adresini alıyoruz
            // var isveren = model.IsVerenKayit.FirstOrDefault;


        }
        [HttpGet]
        public ActionResult IlanGuncelle(int id)
        {
            Ilan ilan = model.Ilan.FirstOrDefault(i => i.ilanId == id);
            
            List<IsKategori> kategori = model.IsKategori.ToList();
            List<IlanPozisyonSeviye> seviye = model.IlanPozisyonSeviye.ToList();
            ViewBag.CurrentUserId = HttpContext.User.Identity.Name;
            ViewBag.Kategoriler = kategori;
            ViewBag.ilanSeviye = seviye;

            return View(ilan); // 'ilan' modeli view'a gönderiliyor
        }
        [HttpPost]
        public ActionResult IlanGuncelle(Ilan model1)
        {
            var isverenad = model.IsVerenKayit.FirstOrDefault(x => x.isVerenId == model1.isVerenId);
            
            string isverenadi = isverenad.isVerenSirketAdi;
            var id = model.IsVerenKayit.FirstOrDefault(i => i.isVerenSirketAdi == isverenadi);
            model1.isVerenId = id.isVerenId;

            //string tanitim = model1.ilanTanitimId.ToString();

            //model.IlanTanitim.Add(tanitim);
            //model.IlanTanitim.AddOrUpdate(tanitim);

            //var tnt = model.IlanTanitim.FirstOrDefault(i => i.ilanOzet == tanitim);


            model.Ilan.AddOrUpdate(model1);
            model.SaveChanges();
            if (User.IsInRole("1"))
            {
                return RedirectToAction("Index", "Ilanlar");

            }
            else
            {
                return RedirectToAction("Ilanlar");

            }
        }
        
        public void IlanSil(int id)
        {
            Ilan ilan = model.Ilan.FirstOrDefault(x => x.ilanId == id);
            if (ilan != null)

            {
                
                model.Ilan.Remove(ilan);
                model.SaveChanges();
            }
            //return RedirectToAction("Ilanlar");,
        }
       
    }
}