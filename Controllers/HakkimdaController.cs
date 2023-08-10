using DbMvc.Models.Entity;
using DbMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbMvc.Models.Entity;
using DbMvc.Repositories;

namespace DbMvc.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        CVEntities db=new CVEntities();
        GenericRepository<Tbl_About> repo = new GenericRepository<Tbl_About>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(Tbl_About p)
        {
            var t = repo.Find(x => x.ID >= 0);
            t.name = p.name;
            t.surname = p.surname;
            t.addres = p.addres;
            t.phone = p.phone;
            t.mail= p.mail;
            t.comment= p.comment;
            t.image= p.image;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}