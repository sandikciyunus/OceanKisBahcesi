using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("/product/{path}/{IsSubProdouct}")]
        public IActionResult Index(string path,int IsSubProdouct)
        {
            string dil = "";
            ProductDetailViewModel model = new ProductDetailViewModel();
            if (HttpContext.Request.Query["language"].ToString() != null)
            {
                dil = HttpContext.Request.Query["language"].ToString();
                switch (dil)
                {
                    case "tr-TR":
                        model.ProductDetails = _productService.GetAllByTR(path, IsSubProdouct);
                        model.ProductImages = _productService.GetImages(path, IsSubProdouct);
                        model.ProductVideos = _productService.GetVideoByPath(path);
                        model.MainImage = _productService.GetByPath(path);
                        model.Product2DImage =  _productService.GetByPath2DImage(path);
                        model.SubProductName = _productService.ProductNameTR(path);
                        break;
                    case "en-US":
                        model.ProductDetails = _productService.GetAllByENG(path, IsSubProdouct);
                        model.ProductImages = _productService.GetImages(path, IsSubProdouct);
                        model.ProductVideos = _productService.GetVideoByPath(path);
                        model.MainImage = _productService.GetByPath(path);
                        model.Product2DImage = _productService.GetByPath2DImage(path);
                        model.SubProductName = _productService.ProductNameENG(path);
                        break;
                    default:
                        model.ProductDetails = _productService.GetAllByTR(path, IsSubProdouct);
                        model.ProductImages = _productService.GetImages(path, IsSubProdouct);
                        model.ProductVideos = _productService.GetVideoByPath(path);
                        model.MainImage = _productService.GetByPath(path);
                        model.Product2DImage = _productService.GetByPath2DImage(path);
                        model.SubProductName = _productService.ProductNameTR(path);
                        break;
                }
            }
            return View(model);
        }
    }
}
