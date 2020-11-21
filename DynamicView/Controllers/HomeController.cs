using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeTheme(string theme)
        {
            Response.Cookies.Add(new HttpCookie("theme", theme));
            return RedirectToAction("Index");
        }
    }
}