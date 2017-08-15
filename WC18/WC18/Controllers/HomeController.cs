using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WC18.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View("Index.en");
            return View();
        }

        public ActionResult Program()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Speakers()
        {
            return View();
        }

        public ActionResult ChangeLanguage()
        {
            return View();
        }
    }
}