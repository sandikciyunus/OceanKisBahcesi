using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using OceanKisBahcesi.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OceanKisBahcesi.WebUI.Models;

namespace OceanKisBahcesi.WebUI.ViewComponents
{
    [ViewComponent]
    public class NavbarViewComponent:ViewComponent
    {
        private IProductService _productService;
        public NavbarViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            string dil = "";
            ProductListViewModel model = new ProductListViewModel();
            if(HttpContext.Request.Query["language"].ToString() != null)
            {
                dil = HttpContext.Request.Query["language"].ToString();
                switch (dil)
                {
                    case "tr-TR":
                        model.Products = _productService.GetAllTR();
                        break;
                    case "en-US":
                        model.Products = _productService.GetAllENG();
                        break;
                    default:
                        model.Products = _productService.GetAllTR();
                        break;
                }
            }
            return View(model);
        }
    }
}
