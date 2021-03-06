using Core.DataAccess.Entity_Framework;
using Microsoft.EntityFrameworkCore;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using OceanKisBahcesi.DataAccess.Helper;
using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OceanKisBahcesi.DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        private readonly OceanContext _context;
        public EfProductDal(OceanContext context) : base(context)
        {
            _context = context;
        }

        public void AddSubProductDescription(ProductDescription productDescription)
        {
            _context.ProductDescriptions.Add(productDescription);
            _context.SaveChanges();
        }

        public IList<SubProduct> GetAll()
        {
            return _context.SubProducts.Include(p => p.Product).Include(p => p.Language).ToList();
        }

        public List<ProductDetailModel> GetAllByENG(string path, int IsSubProdouct)
        {

            var productDescriptions = _context.ProductDescriptions.Where(p => p.LanguageId == 2 && p.Path == path && p.IsSubProduct == IsSubProdouct).ToList();
            List<ProductDetailModel> result = new List<ProductDetailModel>();
            foreach (var item in productDescriptions)
            {
                var product = _context.Products.Where(p => p.Id == item.ProductId && p.LanguageId == 2).FirstOrDefault();
                var subProduct = _context.SubProducts.Where(p => p.Id == item.ProductId && p.LanguageId == 2).FirstOrDefault();
                if (product != null)
                {
                    result.Add(new ProductDetailModel
                    {
                        Id = item.Id,
                        ProductName = product.Name,
                        Feauture = item.Feature,
                        DescriptionName = item.DescriptionName,
                        Description = item.Description
                    });
                }
                else
                {
                    result.Add(new ProductDetailModel
                    {
                        Id = item.Id,
                        ProductName = subProduct.Name,
                        Feauture = item.Feature,
                        DescriptionName = item.DescriptionName,
                        Description = item.Description
                    });
                }

            }
            return result;

        }

        public List<ProductDetailModel> GetAllByTR(string path, int IsSubProdouct)
        {
            var productDescriptions = _context.ProductDescriptions.Where(p => p.LanguageId == 1 && p.Path == path && p.IsSubProduct == IsSubProdouct).ToList();
            List<ProductDetailModel> result = new List<ProductDetailModel>();
            foreach (var item in productDescriptions)
            {
                var product = _context.Products.Where(p => p.Id == item.ProductId && p.LanguageId == 1).FirstOrDefault();
                var subProduct = _context.SubProducts.Where(p => p.Id == item.ProductId && p.LanguageId == 1).FirstOrDefault();
                if (product != null)
                {
                    result.Add(new ProductDetailModel
                    {
                        Id = item.Id,
                        ProductName = product.Name,
                        Feauture = item.Feature,
                        DescriptionName = item.DescriptionName,
                        Description = item.Description
                    });
                }
                else
                {
                    result.Add(new ProductDetailModel
                    {
                        Id = item.Id,
                        ProductName = subProduct.Name,
                        Feauture = item.Feature,
                        DescriptionName = item.DescriptionName,
                        Description = item.Description
                    });
                }
            }
            return result;
        }

        public IList<Product> GetAllENG()
        {

            return _context.Products.Include(p => p.SubProducts).Where(p => p.LanguageId == 2).ToList();

        }

        public IList<Product> GetAllTR()
        {
            return _context.Products.Include(p => p.SubProducts).Where(p => p.LanguageId == 1).ToList();
        }

        public SubProduct GetById(int id)
        {
            return _context.SubProducts.Where(p => p.Id == id).FirstOrDefault();
        }

        public IList<ProductDescription> GetByProductId(int productId)
        {
            return _context.ProductDescriptions.Where(p => p.ProductId==productId && p.IsSubProduct==1).ToList();
        }
        public IList<ProductDescription> GetByProductId2(int productId)
        {
            return _context.ProductDescriptions.Where(p => p.ProductId == productId && p.IsSubProduct == 0).ToList();
        }

        public ProductMainImage GetByPath(string path)
        {
            return _context.ProductMainImages.Where(p => p.Path == path).FirstOrDefault();
        }

        public Product2DImage GetByPath2DImage(string path)
        {
            return _context.Product2DImages.Where(p => p.Path == path).FirstOrDefault();
        }

        public List<ProductImage> GetImages(string path, int IsSubProdouct)
        {
            return _context.ProductImages.Where(p => p.Path == path && p.IsSubProduct == IsSubProdouct).ToList();
        }

        public IList<ProductVideo> GetVideoByPath(string path)
        {
            return _context.ProductVideos.Where(p => p.Path == path).ToList();
        }

        public string ProductNameENG(string path)
        {
            var product = _context.SubProducts.Where(p => p.Path == path && p.LanguageId == 2).FirstOrDefault();
            return product.Name;
        }

        public string ProductNameTR(string path)
        {
            var product = _context.SubProducts.Where(p => p.Path == path && p.LanguageId == 1).FirstOrDefault();
            return product.Name;

        }

        public string ProductNameENG2(string path)
        {
            var product = _context.Products.Where(p => p.Path == path && p.LanguageId == 2).FirstOrDefault();
            return product.Name;
        }

        public string ProductNameTR2(string path)
        {
            var product = _context.Products.Where(p => p.Path == path && p.LanguageId == 1).FirstOrDefault();
            return product.Name;

        }

        public void DeleteProductDescription(int id)
        {
            var deleteProductDescription = _context.ProductDescriptions.Where(p => p.Id == id).FirstOrDefault();
            _context.ProductDescriptions.Remove(deleteProductDescription);
            _context.SaveChanges();
        }

        public ProductImage GetProductImageByPath(string path)
        {
            return _context.ProductImages.Where(p => p.Path == path).FirstOrDefault();
        }

        public IList<ProductImage> ListProductImagesGetByPath(string path)
        {
            return _context.ProductImages.Where(p => p.Path == path).ToList();
        }

        public void AddProductImage(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            _context.SaveChanges();
        }

        public void DeleteProductImage(int id)
        {
            var productImage = _context.ProductImages.Where(p => p.Id == id).FirstOrDefault();
            _context.ProductImages.Remove(productImage);
            _context.SaveChanges();
        }

        public void AddProduct2DImage(Product2DImage product2DImage)
        {
            var update2DImage = _context.Product2DImages.Where(p => p.Path == product2DImage.Path).FirstOrDefault();
            update2DImage.Image = product2DImage.Image;
            _context.Product2DImages.Update(update2DImage);
            _context.SaveChanges();
        }

        public void DeleteProduct2DImage(int id)
        {
            var product2DImage = _context.Product2DImages.Where(p => p.Id == id).FirstOrDefault();
            _context.Product2DImages.Remove(product2DImage);
            _context.SaveChanges();
        }

        public int GetByPathProduct2DImageCount(string path)
        {
            return _context.Product2DImages.Where(p => p.Path == path).Count();
        }

        public void UpdateSubProducts(SubProduct subProduct)
        {
            var updateSubProduct = _context.SubProducts.Where(p => p.Id == subProduct.Id).FirstOrDefault();
            updateSubProduct.Name = subProduct.Name;
            updateSubProduct.ProductId = subProduct.ProductId;
            _context.SubProducts.Update(updateSubProduct);
            _context.SaveChanges();
        }

        public IList<Product> GetAllWithLanguage()
        {
            return _context.Products.Include(p => p.Language).Include(p=>p.SubProducts).ToList();
        }

        public IList<Language> GetAllLanguages()
        {
            return _context.Languages.ToList();
        }

        public void UpdateProducts(Product product)
        {
            var updateProduct = _context.Products.Where(p => p.Id == product.Id).FirstOrDefault();
            updateProduct.Name = product.Name;
            updateProduct.LanguageId = product.LanguageId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
        }

        public int CountProduct2DImages(string path)
        {
            return _context.Product2DImages.Where(p => p.Path == path).Count();
        }

        public void Add2DImageProduct(Product2DImage product2DImage)
        {
            _context.Product2DImages.Add(product2DImage);
            _context.SaveChanges();
        }

        public ProductVideo GetProductVideoByPath(string path)
        {
            return _context.ProductVideos.Where(p => p.Path == path).FirstOrDefault();
        }

        public void AddProductVideo(ProductVideo productVideo)
        {
            productVideo.Url = StringExtensions.UrlToEmbedCode(productVideo.Url);
            _context.ProductVideos.Add(productVideo);
            _context.SaveChanges();
        }

        public int CountVideGetByPath(string path)
        {
            return _context.ProductVideos.Where(p => p.Path == path).Count();
        }

        public void DeleteVideo(ProductVideo productVideo)
        {
            _context.ProductVideos.Remove(productVideo);
            _context.SaveChanges();
        }

        public ProductVideo GetProductVideoById(int id)
        {
            return _context.ProductVideos.Where(p => p.Id == id).FirstOrDefault();
        }

        public IList<ProductMainImage> ListProductProductMainImageGetByPath(string path)
        {
            return _context.ProductMainImages.Where(p => p.Path == path).ToList();
        }

        public void AddProductImage(ProductMainImage productMainImage)
        {
            _context.ProductMainImages.Add(productMainImage);
            _context.SaveChanges();
        }

        public int CountMainImageGetByPath(string path)
        {
            return _context.ProductMainImages.Where(p => p.Path == path).Count();
        }

        public void DeleteMainImage(ProductMainImage productMainImage)
        {
            _context.ProductMainImages.Remove(productMainImage);
            _context.SaveChanges();
        }

        public ProductMainImage GetProductImageById(int id)
        {
            return _context.ProductMainImages.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetByProductId3(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public void AddSubProduct(SubProduct subProduct)
        {
            _context.SubProducts.Add(subProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void DeleteSubProduct(SubProduct subProduct)
        {
            _context.SubProducts.Remove(subProduct);
            _context.SaveChanges();
        }
    }
}
