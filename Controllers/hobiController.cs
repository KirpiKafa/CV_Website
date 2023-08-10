using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbMvc.Models.Entity;
using DbMvc.Repositories;

namespace DbMvc.Controllers
{
    public class hobiController : Controller
    {
        // GET: hobi
        GenericRepository<Tbl_Hobbys> repo = new GenericRepository<Tbl_Hobbys>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hobbys p)
        {
            var t = repo.Find(x => x.ID >= 0);
            t.comment = p.comment;
            t.comment2 = p.comment2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}