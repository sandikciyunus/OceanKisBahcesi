using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ISliderService _sliderService;
        private IServiceService _serviceService;
        private IFeatureService _featureService;
        public HomeController(ISliderService sliderService,IServiceService serviceService,IFeatureService featureService)
        {
            _sliderService = sliderService;
            _serviceService = serviceService;
            _featureService = featureService;
        }
        public IActionResult Index()
        {
            string dil = "";
            HomeViewModel model = new HomeViewModel();
            if (HttpContext.Request.Query["language"].ToString() != null)
            {
                dil = HttpContext.Request.Query["language"].ToString();
                switch (dil)
                {
                    case "tr-TR":
                        model.Services = _serviceService.GetAllTR();
                        model.Sliders = _sliderService.GetAll();
                        model.HomeVideos = _sliderService.GetAllHomeVideo();
                        model.Features = _featureService.GetAllTR();
                        ViewBag.slogan = "Beklentilerin Üstünde ve Ötesinde….";
                        break;
                    case "en-US":
                        model.Services = _serviceService.GetAllENG();
                        model.Sliders = _sliderService.GetAll();
                        model.HomeVideos = _sliderService.GetAllHomeVideo();
                        model.Features = _featureService.GetAllENG();
                        ViewBag.slogan = "Above and Beyond Expactations...";
                        break;
                    default:
                        model.Services = _serviceService.GetAllTR();
                        model.Sliders = _sliderService.GetAll();
                        model.HomeVideos = _sliderService.GetAllHomeVideo();
                        model.Features = _featureService.GetAllTR();
                        ViewBag.slogan = "Beklentilerin Üstünde ve Ötesinde….";
                        break;
                }
            }
            return View(model);
        }
    }
}
