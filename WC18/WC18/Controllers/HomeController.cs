using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WC18.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string lang = "")
        {
            string vn = "Index" + DefineUICulture(lang);
            return View(vn);
        }

        public ActionResult Program(string lang = "")
        {
            string vn = "Program" + DefineUICulture(lang);
            return View(vn);
        }

        public ActionResult Registration(string lang = "")
        {
            string vn = "Registration" + DefineUICulture(lang);
            return View(vn);
        }

        public ActionResult Speakers(string lang = "")
        {
            string vn = "Speakers" + DefineUICulture(lang);
            return View(vn);
        }

        public ActionResult SponsorInfo(string lang = "")
        {
            string vn = "SponsorInfo" + DefineUICulture(lang);
            return View(vn);
        }

        private string DefineUICulture(string lang)
        {
            if (lang != null && !string.IsNullOrWhiteSpace(lang))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            }
            else
            {
                // load the culture info from the cookie
                var cookie = HttpContext.Request.Cookies["WC18.CurrentUICulture"];
                var langHeader = string.Empty;

                if (cookie != null)
                {
                    // set the culture by the cookie content
                    langHeader = cookie.Value;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                else
                {
                    // set the culture by the location if not speicified
                    langHeader = HttpContext.Request.UserLanguages[0];
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
            }
            // save the location into cookie
            HttpCookie _cookie = new HttpCookie("WC18.CurrentUICulture", Thread.CurrentThread.CurrentUICulture.Name);

            _cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Response.SetCookie(_cookie);
            
            // Se retorna el sufijo para el nombre de la vista
            return (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en") ? ".en" : ""; ;
        }
    }
}