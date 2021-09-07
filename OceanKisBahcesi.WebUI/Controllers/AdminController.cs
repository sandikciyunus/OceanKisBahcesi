﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private IAboutService _aboutService;
        private IAddressInformationService _addressInformationService;
        public AdminController(IProductService productService, IAboutService aboutService, IAddressInformationService addressInformationService)
        {
            _productService = productService;
            _aboutService = aboutService;
            _addressInformationService = addressInformationService;
        }
        public IActionResult SubProductList()
        {
            return View(new SubProductListViewModel
            {
                SubProducts = _productService.GetAll()
            });
        }

        public IActionResult SubProductFeature(int id)
        {
            return View(new SubProductViewModel
            {
                SubProduct = _productService.GetById(id),
                ProductDescriptions = _productService.GetByProductId(id)
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
        public IActionResult SubProductDescription(int id)
        {
            return View(new SubProductViewModel
            {
                SubProduct = _productService.GetById(id),
                ProductDescriptions = _productService.GetByProductId(id)
            });
        }

        [HttpPost]
        public IActionResult AddSubProductDescription(ProductDescription productDescription)
        {
            if (productDescription.Description == null)
            {
                return Json(new { success = false, message = "Açıklama boş bırakılamaz" });
            }
            _productService.AddSubProductDescription(productDescription);
            return Json(new { success = true, message = "Açıklama başarıyla eklendi" });
        }

        public IActionResult DeleteSubProductDescription(int id)
        {
            _productService.DeleteProductDescription(id);
            return Json(new { success = true, message = "Açıklama başarıyla silindi" });
        }
        public IActionResult SubProductImage(string path)
        {
            return View(new ProductImageViewModel
            {
                ProductImage = _productService.GetProductImageByPath(path),
                ProductImages = _productService.ListProductImagesGetByPath(path)
            });
        }


        public IActionResult AddSubProductImage(ProductImage productImage, IFormFile file)
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

        public IActionResult AboutList()
        {
            return View(new AboutListViewModel
            {
                Abouts = _aboutService.GetAll()
            });
        }

        public IActionResult AboutUpdate(int id)
        {
            return View(new AboutViewModel
            {
                About = _aboutService.GetById(id)
            });
        }

        public IActionResult UpdateAbout(About about)
        {
            _aboutService.Update(about);
            return Json(new { success = true, message = "Başarıyla güncellendi" });
        }

        public IActionResult ContactList()
        {
            return View(new ContactListViewModel
            {
                AddressInformations = _addressInformationService.GetAll()
            });
        }

        public IActionResult ContactUpdate(int id)
        {
            return View(new ContactViewModel
            {
                AddressInformations = _addressInformationService.GetById(id)
            });
        }

        public IActionResult UpdateContact(AddressInformation addressInformation)
        {
            if (addressInformation.Address == null)
            {
                return Json(new { success = false, message = "Adres alanı boş bırakılamaz" });
            }
            if (addressInformation.Email == null)
            {
                return Json(new { success = false, message = "Email alanı boş bırakılamaz" });
            }
            if (addressInformation.Phone == null)
            {
                return Json(new { success = false, message = "Telefon alanı boş bırakılamaz" });
            }
            _addressInformationService.Update(addressInformation);
            return Json(new { success = true, message = "Başarıyla güncellendi" });

        }

        public IActionResult Image2D(string path)
        {
            return View(new ProductDetailViewModel
            {
                Product2DImage = _productService.GetByPath2DImage(path)
            });
        }

        public IActionResult AddSubProduct2DImage(Product2DImage product2DImage, IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false, message = "Resim seçmek zorundasınız" });
            }
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/2DImages/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            product2DImage.Image = fileName;
            _productService.AddProduct2DImage(product2DImage);
            return Json(new { success = true, message = "Resim başarıyla eklendi" });
        }

        public IActionResult DeleteSubProduct2DImage(int id)
        {
                _productService.DeleteProduct2DImage(id);
                return Json(new { success = true, message = "Resim başarıyla silindi" });
        }
    }
}
