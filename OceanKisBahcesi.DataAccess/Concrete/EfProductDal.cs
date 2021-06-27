﻿using Core.DataAccess.Entity_Framework;
using Microsoft.EntityFrameworkCore;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {
        private readonly OceanContext _context;
        public EfProductDal(OceanContext context) : base(context)
        {
            _context = context;
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
    }
}