using DbMvc.Models.Entity;
using DbMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbMvc.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();




        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Experience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            Tbl_Experience t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Tbl_Experience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Experience p)
        {
            Tbl_Experience t = repo.Find(x => x.ID == p.ID );
            t.title= p.title;
            t.subtitle=p.subtitle;
            t.comment = p.comment;
            t.date = p.date;
            repo.TUpdate(t);
            return RedirectToAction("Index") ;
        }
    }

}