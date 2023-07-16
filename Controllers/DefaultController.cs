using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbMvc.Models.Entity;

namespace DbMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        CVEntities db = new CVEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_About.ToList();
            return View(degerler);
        }
    }
}