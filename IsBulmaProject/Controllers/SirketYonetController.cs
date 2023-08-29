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
    public class SirketYonetController : Controller
    {
        // GET: Admin
        IsBulmaEntities model = new IsBulmaEntities();
        [MyAuthorization(Roles = "1")]

        public ActionResult Sirket()
        {
            var sirket = model.IsVerenKayit.ToList();
            ViewBag.Sirket = sirket;
            return View();
        }
        [HttpGet]
        [MyAuthorization(Roles = "1")]
        public ActionResult SirketEkle()
        {

            return View();
        }
        [HttpPost]
        [MyAuthorization(Roles = "1")]

        public ActionResult SirketEkle(IsVerenKayit isveren)
        {
            model.IsVerenKayit.AddOrUpdate(isveren);
            model.SaveChanges();
            return RedirectToAction("Sirket");

        }
        [MyAuthorization(Roles = "1")]

        public void SirketSil(int id)
        {
            var isvrn = model.IsVerenKayit.FirstOrDefault(x => x.isVerenId == id);
            if (isvrn != null)
            {
                model.IsVerenKayit.Remove(isvrn);
                model.SaveChanges();
            }
            //return RedirectToAction("Ilanlar");
        }
        [HttpGet]
        public ActionResult SirketGuncelle(int id)
        {
            var isveren = model.IsVerenKayit.FirstOrDefault(x => x.isVerenId == id);

            return View(isveren);
        }
        [HttpPost]
        public ActionResult SirketGuncelle(IsVerenKayit isveren)
        {
            model.IsVerenKayit.AddOrUpdate(k => k.isVerenId, isveren);
            Console.WriteLine(isveren.isVerenId);
            model.SaveChanges();
            return RedirectToAction("Sirket");
        }
    }
}
