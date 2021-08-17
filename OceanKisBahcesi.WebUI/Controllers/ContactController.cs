using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private IAddressInformationService _addressInformationService;
        public ContactController(IAddressInformationService addressInformationService)
        {
            _addressInformationService = addressInformationService;
        }
        [Route("/contact")]
        public IActionResult Index()
        {
            string dil = "";
            ContactViewModel model = new ContactViewModel();
            if (HttpContext.Request.Query["language"].ToString() != null)
            {
                dil = HttpContext.Request.Query["language"].ToString();
                switch (dil)
                {
                    case "tr-TR":
                        model.AddressInformations = _addressInformationService.GetAllTR();
                        break;
                    case "en-US":
                        model.AddressInformations = _addressInformationService.GetAllENG();
                        break;
                    default:
                        model.AddressInformations = _addressInformationService.GetAllTR();
                        break;
                }
            }
            return View(model);
        }


        public IActionResult SendMail(MailModel model)
        {
            if (model.Fullname==null)
            {
                return Json(new { success = false, message = "You have to fill in all fields." });
            }
            if (model.Email==null)
            {
                return Json(new { success = false, message = "You have to fill in all fields." });
            }  
            
            if (model.Phone==null)
            {
                return Json(new { success = false, message = "You have to fill in all fields." });
            }
              
            if (model.Subject==null)
            {
                return Json(new { success = false, message = "You have to fill in all fields." });
            }    
            
            if (model.Message==null)
            {
                return Json(new { success = false, message = "You have to fill in all fields." });
            }
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            sc.Credentials = new NetworkCredential("oceankisbahcesibilgi@gmail.com", "ocean.2021");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("oceankisbahcesibilgi@gmail.com", "oceankisbahcesibilgi@gmail.com");
            mail.To.Add("info@oceankisbahcesi.com");
            //mail.To.Add("e.yunussandikcii@gmail.com");
            mail.Subject = model.Subject;
            mail.IsBodyHtml = true;
            mail.Body = "Ad: "+model.Fullname+"<br>"+
                "Email: "+model.Email+"<br>"+
                "Telefon: "+model.Phone+"<br>"+
                "Konu: "+model.Subject+"<br>"+
                "Mesaj: "+model.Message;
            sc.Send(mail);
            return Json(new { success = true });
        }

    }
}
