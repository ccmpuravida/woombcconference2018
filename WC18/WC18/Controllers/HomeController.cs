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
            model.Date = DateTime.Now;

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

                // Lectura de valores de configuración
                var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");


                // Si ha llegado hasta aquí y se tiene problemas con el envio del correo
                // dejar que la aplicación continue cu ejecución
                try
                {
                    MailMessage msg = new MailMessage();
                    var from = new MailAddress(smtpSection.From, "WOOMB International Conference 2018");
                    msg.IsBodyHtml = true;
                    msg.From = from;
                    msg.ReplyToList.Add(from);
                    msg.To.Add(new MailAddress(model.Email));
                    msg.CC.Add(new MailAddress("info@woombconference2018.com"));
                    msg.Subject = "WOOMB International Conference 2018";

                    // TODO Habría que consisderar que el cuerpo del correo responda al idioma de registro
                    // utilizado.
                    
                    msg.Body = MainResources.Mail1 + $"<strong>{model.Name}</strong><br/>" +
                        $"<p>"+MainResources.Mail2+"</p>";

                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(msg);
                }
                catch (Exception)
                {
                    // Dado que hubo un error el envíar el correo se deja que la aplicación continue la ejecución
                }

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