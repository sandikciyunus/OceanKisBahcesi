using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [Route("/about")]
        public IActionResult Index()
        {
            string dil = "";
            AboutListViewModel model = new AboutListViewModel();
            if (HttpContext.Request.Query["language"].ToString() != null)
            {
                dil = HttpContext.Request.Query["language"].ToString();
                switch (dil)
                {
                    case "tr-TR":
                        model.Abouts = _aboutService.GetAllTR();
                        break;
                    case "en-US":
                        model.Abouts = _aboutService.GetAllENG();
                        break;
                    default:
                        model.Abouts = _aboutService.GetAllTR();
                        break;
                }
            }
            return View(model);
        }
    }
}
