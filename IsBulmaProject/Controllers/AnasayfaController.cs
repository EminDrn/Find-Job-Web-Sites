using IsBulmaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsBulmaProject.Controllers
{
    public class AnasayfaController : Controller
    {
        IsBulmaEntities model = new IsBulmaEntities();
        // GET: Anasayfa
        public ActionResult Index()
        {
            List<v_IlanlarByIsVerenId> k = model.v_IlanlarByIsVerenId
           .OrderBy(i => i.IlanEklenmeTarihi)
           .Take(6) // İlk 6 ilanı al
           .ToList();
            return View(k);
        }
        public ActionResult Hakkımızda()
        {
            return View();
        }
    }
}