using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbMvc.Models.Entity;
using DbMvc.Repositories;
namespace DbMvc.Controllers

{
    public class YenetekController : Controller
    {
        // GET: Yenetek
 
        GenericRepository<Tbl_Skills> repo=new GenericRepository<Tbl_Skills>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Tbl_Skills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.Tdelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(Tbl_Skills t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.skill = t.skill;
            y.rate = t.rate;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}