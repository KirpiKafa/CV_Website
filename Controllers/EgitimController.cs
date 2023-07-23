using DbMvc.Models.Entity;
using DbMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DbMvc.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Tbl_Education> repo = new GenericRepository<Tbl_Education>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Education p)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim=repo.Find(x => x.ID == id);
            repo.Tdelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x=> x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(Tbl_Education t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.title= t.title;
            egitim.subtitle=t.subtitle;
            egitim.subtitle2=t.subtitle2;
            egitim.gno = t.gno;
            egitim.date = t.date;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }


    }
}