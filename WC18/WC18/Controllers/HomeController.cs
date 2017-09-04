using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WC18.Models;

namespace WC18.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string lang = "")
        {
            string vn = "Index" + DefineUICulture(lang);
            //string vn = "Index";
            ViewBag.Title = MainResources.HomeTitle;
            ViewBag.Description = MainResources.HomeDesc;
            return View(vn);
        }

        public ActionResult Program(string lang = "")
        {
            string vn = "Program" + DefineUICulture(lang);
            return View(vn);
        }

        [HttpGet]
        public ActionResult Registration(string lang = "")
        {
            string vn = "Registration" + DefineUICulture(lang);
            return View(vn);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registration(WC18.Models.Registration model)
        {
            if (ModelState.IsValid)
            {
                // Guardar el registro en base de datos
                using (var db = new WCContext())
                {
                    db.Registrations.Add(model);
                    db.SaveChanges();
                }

                // Hacer envío de correos
                // La configuración del servidor SMTP está en la sección del web.config
                //SmtpClient client = new SmtpClient();
                //MailMessage mail = new MailMessage();
                //mail.To.Add(new MailAddress(model.Email));
                //mail.Subject = "WOOMB International Conference 2018";
                //mail.Body = "DEMO";
                //client.Send(mail);

                // Lectura de valores de configuración
                var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                MailMessage msg = new MailMessage();
                var from = new MailAddress(smtpSection.From, "WOOMB International Conference 2018");
                msg.From = from;
                msg.ReplyToList.Add(from);
                msg.To.Add(new MailAddress(model.Email));
                msg.Subject = "WOOMB International Conference 2018";
                msg.Body = "DEMO";

                SmtpClient smtp = new SmtpClient();
                //smtp.Send(msg);


                // Todo listo se pasan los datos a la confirmación de registro
                TempData["Registration"] = model;
                return RedirectToAction("RegistrationConfirm");
            }

            string vn = "Registration" + DefineUICulture("");
            return View(vn, model);
        }

        public ActionResult RegistrationConfirm()
        {
            var model = (WC18.Models.Registration)TempData["Registration"];

            if (model == null)
            {
                return RedirectToAction("Registration");
            }

            return View(model);
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
                    //langHeader = HttpContext.Request.UserLanguages[0];
                    langHeader = "en-US";
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
            }
                // save the location into cookie
                HttpCookie _cookie = new HttpCookie("WC18.CurrentUICulture", Thread.CurrentThread.CurrentUICulture.Name)
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Response.SetCookie(_cookie);

            // Se retorna el sufijo para el nombre de la vista
            return (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en") ? ".en" : ""; ;
        }
    }
}