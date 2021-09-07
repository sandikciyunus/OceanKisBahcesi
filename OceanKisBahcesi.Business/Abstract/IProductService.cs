using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IProductService
    {
        IList<Product> GetAllTR();
        IList<Product> GetAllTR2();
        IList<Product> GetAllENG();
        IList<SubProduct> GetAll();
        IList<ProductDescription> GetByProductId(int productId);
        IList<ProductImage> ListProductImagesGetByPath(string path);
        SubProduct GetById(int id);
        IList<ProductVideo> GetVideoByPath(string path);
        ProductImage GetProductImageByPath(string path);
        List<ProductDetailModel> GetAllByTR(string path, int IsSubProdouct);
        List<ProductDetailModel> GetAllByENG(string path, int IsSubProdouct);
        List<ProductImage> GetImages(string path, int IsSubProdouct);
        ProductMainImage GetByPath(string path);
        Product2DImage GetByPath2DImage(string path);
        string ProductNameTR(string path);
        string ProductNameENG(string path);
        void AddSubProductDescription(ProductDescription productDescription);
        void DeleteProductDescription(int id);
        void AddProductImage(ProductImage productImage);
        void DeleteProductImage(int id);
        void AddProduct2DImage(Product2DImage product2DImage);
        void DeleteProduct2DImage(int id);
        int GetByPathProduct2DImageCount(string path);
    }
}
