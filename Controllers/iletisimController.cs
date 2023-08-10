using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbMvc.Models.Entity;
using DbMvc.Repositories;

namespace DbMvc.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbl_Communication> repo = new GenericRepository<Tbl_Communication>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}