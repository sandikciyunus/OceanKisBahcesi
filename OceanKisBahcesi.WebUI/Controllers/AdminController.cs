using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private IAboutService _aboutService;
        private IAddressInformationService _addressInformationService;
        private IServiceService _serviceService;
        private ISliderService _sliderService;
        private IFeatureService _featureService;
        public AdminController(IProductService productService, IAboutService aboutService, IAddressInformationService addressInformationService, IServiceService serviceService, ISliderService sliderService, IFeatureService featureService)
        {
            _productService = productService;
            _aboutService = aboutService;
            _addressInformationService = addressInformationService;
            _serviceService = serviceService;
            _sliderService = sliderService;
            _featureService = featureService;
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

        public IActionResult SubProductUpdate(int id)
        {
            return View(new SubProductModel
            {
                SubProduct = _productService.GetById(id),
                Products = _productService.GetAllProducts()
            });
        }

        public IActionResult UpdateSubProducts(SubProduct subProduct)
        {
            if (subProduct.Name == null)
            {
                return Json(new { success = false, message = "Ürün adı boş bırakılamaz" });
            }
            _productService.UpdateSubProducts(subProduct);
            return Json(new { success = true, message = "Alt ürün başarıyla güncellendi" });
        }

        public IActionResult ProductList()
        {
            return View(new ProductListViewModel
            {
                Products = _productService.GetAllWithLanguage()
            });
        }

        public IActionResult ProductAdd()
        {
            return View(new ProductAddViewModel
            {
                Languages = _productService.GetAllLanguages()
            });
        }
        public IActionResult AddProduct(Product product)
        {
            if (product.Name == null)
            {
                return Json(new { success = false, message = "Ürün adı boş bırakılamaz" });
            }
            if (product.Path == null)
            {
                return Json(new { success = false, message = "Path boş bırakılamaz" });
            }
            _productService.AddProduct(product);
            return Json(new { success = true, message = "Ürün başarıyla güncellendi" });

        }

        public IActionResult ProductUpdate(int id)
        {
            return View(new ProductUpdateViewModel
            {
                Product = _productService.GetProductById(id),
                Languages = _productService.GetAllLanguages()
            });
        }


        public IActionResult UpdateProducts(Product product)
        {
            if (product.Name == null)
            {
                return Json(new { success = false, message = "Ürün adı boş bırakılamaz" });
            }
            _productService.UpdateProduct(product);
            return Json(new { success = true, message = "Ürün başarıyla güncellendi" });
        }

        public IActionResult ProductDescription(int id)
        {
            return View(new ProductViewModel
            {
                Product = _productService.GetProductById(id),
                ProductDescriptions = _productService.GetByProductId2(id)
            });
        }

        public IActionResult ProductFeature(int id)
        {
            return View(new ProductViewModel
            {
                Product = _productService.GetProductById(id),
                ProductDescriptions = _productService.GetByProductId2(id)
            });
        }
        public IActionResult ProductImage2D(string path, int id)
        {
            return View(new ProductViewModel
            {
                Product = _productService.GetProductById(id),
                Product2DImage = _productService.GetByPath2DImage(path),
                Count2DImages = _productService.CountProduct2DImages(path)
            });
        }

        public IActionResult ProductImage(string path, int id)
        {
            return View(new ProductImageViewModel
            {
                Product = _productService.GetProductById(id),
                ProductImages = _productService.ListProductImagesGetByPath(path)
            });
        }

        public IActionResult AddProductImage(ProductImage productImage, IFormFile file)
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
            productImage.IsSubProduct = 0;
            _productService.AddProductImage(productImage);
            return Json(new { success = true, message = "Resim başarıyla eklendi" });
        }
        public IActionResult AddProduct2DImage(Product2DImage product2DImage, IFormFile file)
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
            _productService.Add2DImageProduct(product2DImage);
            return Json(new { success = true, message = "Resim başarıyla eklendi" });
        }

        public IActionResult ServiceList()
        {
            return View(new ServiceListViewModel
            {
                Services = _serviceService.GetAll()
            });
        }

        public IActionResult ServiceUpdate(int id)
        {
            return View(new ServiceViewModel
            {
                Service = _serviceService.GetById(id)
            });
        }

        public IActionResult UpdateService(Service service)
        {
            if (service.Title == null)
            {
                return Json(new { success = false, message = "Başlık alanı boş bırakılamaz" });
            }
            if (service.Description == null)
            {
                return Json(new { success = false, message = "Açıklama alanı boş bırakılamaz" });
            }
            _serviceService.Update(service);
            return Json(new { success = true, message = "Servis başarıyla güncellendi" });

        }

        public IActionResult HomeVideo()
        {
            return View(new HomeVideoListViewModel
            {
                HomeVideos = _sliderService.GetAllHomeVideo()
            });
        }

        public IActionResult HomeVideoUpdate(int id)
        {
            return View(new HomeVideoViewModel
            {
                HomeVideo = _sliderService.GetById(id)
            });
        }

        public IActionResult UpdateHomeVideo(HomeVideo homeVideo, IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false, message = "Video seçmek zorundasınız" });
            }
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Video/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            homeVideo.VideoName = fileName;
            _sliderService.UpdateVideo(homeVideo);
            return Json(new { success = true, message = "Video başarıyla güncellendi" });
        }

        public IActionResult FeatureList()
        {
            return View(new FeatureListViewModel
            {
                Features = _featureService.GetAll()
            });
        }

        public IActionResult FeatureUpdate(int id)
        {
            return View(new FeatureViewModel
            {
                Feature = _featureService.GetById(id)
            });
        }

        public IActionResult UpdateFeature(Feature feature, IFormFile file)
        {
            if (feature.Name == null)
            {
                return Json(new { success = false, message = "Özellik alanı boş bırakılamaz" });
            }
            if (file == null)
            {
                _featureService.UpdateFeatureName(feature);
                return Json(new { success = true, message = "Özellik başarıyla güncellendi" });
            }
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Features/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            feature.Image = fileName;
            _featureService.UpdateFeatureImage(feature);
            return Json(new { success = true, message = "Özellik başarıyla güncellendi" });
        }

        public IActionResult SliderList()
        {
            return View(new SliderListViewModel
            {
                Sliders = _sliderService.GetAll()
            });
        }

        public IActionResult SliderUpdate(int id)
        {
            return View(new SliderViewModel
            {
                Slider = _sliderService.GetBySliderId(id)
            });
        }
        public IActionResult UpdateSlider(Slider slider, IFormFile file)
        {

            if (file == null)
            {
                _sliderService.UpdateIsActive(slider);
                return Json(new { success = true, message = "Başarıyla güncellendi" });
            }
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Sliders/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            slider.Name = fileName;
            _sliderService.UpdateSlider(slider);
            return Json(new { success = true, message = "Başarıyla güncellendi" });
        }

        public IActionResult AddSlider()
        {
            return View();
        }

        public IActionResult SliderAdd(Slider slider, IFormFile file)
        {

            if (file == null)
            {
                return Json(new { success = false, message = "Resim seçmek zorundasınız" });
            }
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Sliders/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            slider.Name = fileName;
            _sliderService.AddSlider(slider);
            return Json(new { success = true, message = "Başarıyla güncellendi" });
        }

        public IActionResult DeleteSlider(int id)
        {
            var slider = _sliderService.GetBySliderId(id);
            if(slider.IsActive==1)
            {
                return Json(new { success = false, message = "Aktif resim silinemez" });
            }
            _sliderService.DeleteSlider(slider);
            return Json(new { success = true, message = "Resim başarıyla silindi" });
        }

        public IActionResult AddSubProductVideo(string path,int id)
        {
            return View(new ProductVideoViewModel
            {
               SubProduct=_productService.GetById(id),
               ProductVideos  = _productService.GetVideoByPath(path)
            });
        }

        public IActionResult SubProductAddVideo(ProductVideo productVideo)
        {
            if(productVideo.Url==null)
            {
                return Json(new { success = false, message = "Url boş bırakılamaz" });
            }
            if (_productService.CountVideGetByPath(productVideo.Path) > 0)
            {
                return Json(new { success = false, message = "Önce var olan videoyu silmelisiniz" });

            }
            _productService.AddProductVideo(productVideo);
            return Json(new { success = true, message = "Video başarıyla eklendi" });
        }
        public IActionResult DeleteVideo(int id)
        {
            var deleteProductVideo = _productService.GetProductVideoById(id);
            _productService.DeleteVideo(deleteProductVideo);
            return Json(new { success = true, message = "Video başarıyla silindi" });

        }

        public IActionResult AddSubProductMainImage(string path, int id)
        {
            return View(new ProductMainImageViewModel
            {
                SubProduct = _productService.GetById(id),
                ProductMainImages = _productService.ListProductProductMainImageGetByPath(path)
            });
        }

        public IActionResult MainImageAdd(ProductMainImage productMainImage, IFormFile file)
        {

            if (file == null)
            {
                return Json(new { success = false, message = "Resim seçmek zorundasınız" });
            }
            if(_productService.CountMainImageGetByPath(productMainImage.Path)>0)
            {
                return Json(new { success = false, message = "Önce var olan ana resmi silmelisiniz" });

            }
            var fileName = file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Products/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            productMainImage.Image = fileName;
            _productService.AddProductImage(productMainImage);
            return Json(new { success = true, message = "Başarıyla güncellendi" });
        }

        public IActionResult DeleteMainImage(int id)
        {
            var deleteProductMainImage = _productService.GetProductImageById(id);
            _productService.DeleteMainImage(deleteProductMainImage);
            return Json(new { success = true, message = "Resim başarıyla silindi" });

        }

        public IActionResult AddProductVideo(string path, int id)
        {
            return View(new ProductVideoViewModel
            {
                Product = _productService.GetByProductId3(id),
                ProductVideos = _productService.GetVideoByPath(path)
            });
        }
        public IActionResult AddProductMainImage(string path, int id)
        {
            return View(new ProductMainImageViewModel
            {
                Product = _productService.GetByProductId3(id),
                ProductMainImages = _productService.ListProductProductMainImageGetByPath(path)
            });
        }

        public IActionResult SubProductAdd()
        {
            return View(new SubProductAddViewModel
            {
                Products=_productService.GetAllWithLanguage(),
                Languages = _productService.GetAllLanguages()
            });
        }

        public IActionResult AddSubProduct(SubProduct subProduct)
        {
            if (subProduct.Name == null)
            {
                return Json(new { success = false, message = "Alt ürün adı boş bırakılamaz" });
            }
            if (subProduct.Path == null)
            {
                return Json(new { success = false, message = "Path boş bırakılamaz" });
            }
            _productService.AddSubProduct(subProduct);
            return Json(new { success = true, message = "Alt ürün başarıyla eklendi" });

        }
    }
}
