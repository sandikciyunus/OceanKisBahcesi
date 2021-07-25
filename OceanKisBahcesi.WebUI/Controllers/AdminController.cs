using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult SubProductList()
        {
            return View(new SubProductListViewModel
            {
                SubProducts=_productService.GetAll()
            });
        }

        public IActionResult SubProductFeature(int id)
        {
            return View(new SubProductViewModel
            {
                SubProduct = _productService.GetById(id),
                ProductDescriptions=_productService.GetByProductId(id)
            });
        }

        [HttpPost]
        public IActionResult AddSubProductFeature(ProductDescription productDescription)
        {
            if (productDescription.Feature == null)
            {
                return Json(new { success = false, message = "Özellik boş bırakılamaz" });
            }
            _productService.AddSubProductDescription(productDescription);
            return Json(new { success = true, message = "Özellik başarıyla eklendi" });
        }

        public IActionResult DeleteSubProductFeature(int id)
        {
            _productService.DeleteProductDescription(id);
            return Json(new { success = true, message = "Özellik başarıyla silindi" });
        }

        public IActionResult SubProductImage(string path)
        {
            return View(new ProductImageViewModel
            {
                ProductImage = _productService.GetProductImageByPath(path),
                ProductImages = _productService.ListProductImagesGetByPath(path)
            });
        }

       
        public IActionResult AddSubProductImage(ProductImage productImage,IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false, message = "Resim seçmek zorundasınız" });
            }
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Products/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            productImage.Image = fileName;
            productImage.IsSubProduct = 1;
            _productService.AddProductImage(productImage);
            return Json(new { success = true, message = "Resim başarıyla eklendi" });
        }

        public IActionResult DeleteProductImage(int id)
        {
            _productService.DeleteProductImage(id);
            return Json(new { success = true, message = "Resim başarıyla silindi" });
        }
    }
}
