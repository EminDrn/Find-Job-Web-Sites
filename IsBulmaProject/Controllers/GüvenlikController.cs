using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IsBulmaProject.Models;

namespace IsBulmaProject.Controllers
{
    [Authorize]
    public class GüvenlikController : Controller
    {
        // GET: Güvenlik
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanici k)
        {
            IsBulmaEntities model = new IsBulmaEntities();
            Kullanici u = model.Kullanici.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.sifre == k.sifre);
            if(u == null)
            {
                ViewBag.hata = "Kullanıcı adı veya kullanıcı şifre hatalı!";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(u.Mail, false);
                Session["kullaniciAdi"] = u.KullaniciAdi;
                Session["kullaniciID"] = u.KullaniciID;

                //Session["kullaniciDT"] = u.dogumTarihi;
                return RedirectToAction("Index" , "Anasayfa");
            }


        }
        [Authorize]
        public ActionResult LogOut()
        {
            //string cookieName = FormsAuthentication.FormsCookieName;
            //string ad = HttpContext.User.Identity.Name;
            //HttpCookie atc = HttpContext.Request.Cookies[cookieName];
            //FormsAuthentication ticket = FormsAuthentication.Decrypt(atc.Value);
            //string isim = ticket.Name;
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Anasayfa");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Kullanici k)
        {
            IsBulmaEntities model = new IsBulmaEntities();
            k.RoleID = 2;
            model.Kullanici.AddOrUpdate(k);
            model.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Hata()
        {
            return View();
        }
    }
}