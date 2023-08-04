using IsBulmaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsBulmaProject.Controllers
{
    public class IlanlarController : Controller
    {
        IsBulmaEntities model = new IsBulmaEntities();
        // GET: Ilanlar

        //[Route("Default-2")]
        [AllowAnonymous]
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

            return View(ilan);
        }
    }
}