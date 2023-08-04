using IsBulmaProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IsBulmaProject.Controllers
{
    
    [AllowAnonymous]
    public class GüvenlikSirketController : Controller
    {
        // GET: GüvenlikSirket
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(IsVerenKayit k)
        {
            IsBulmaEntities model = new IsBulmaEntities();
            IsVerenKayit u = model.IsVerenKayit.FirstOrDefault(x => x.isVerenMail == k.isVerenMail && x.isVerenPassword == k.isVerenPassword);
            if (u == null)
            {
                ViewBag.hata = "Girilen mail  veya  şifre hatalı!";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(u.isVerenSirketAdi, false);
                return RedirectToAction("Index", "Anasayfa");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(IsVerenKayit k)
        {
            IsBulmaEntities model = new IsBulmaEntities();
            model.IsVerenKayit.AddOrUpdate(k);
            model.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Hata()
        {
            return View();
        }
    }
}
