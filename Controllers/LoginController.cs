using DbMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DbMvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            CVEntities db = new CVEntities();
            var bilgi = db.Tbl_Admin.FirstOrDefault(x => x.username == p.username && x.password == p.password);
            if(bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.username, false);
                Session["username"] = bilgi.username.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}