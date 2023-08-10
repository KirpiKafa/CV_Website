using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbMvc.Models.Entity;
using DbMvc.Repositories;

namespace DbMvc.Controllers
{
    
    public class adminController : Controller
    {
        GenericRepository<Tbl_Admin>repo=new GenericRepository<Tbl_Admin>();
        // GET: admin
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Tbl_Admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminDuzenle(Tbl_Admin p)
        {
            Tbl_Admin t = repo.Find(x => x.ID == p.ID);
            t.username = p.username;
            t.password = p.password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}