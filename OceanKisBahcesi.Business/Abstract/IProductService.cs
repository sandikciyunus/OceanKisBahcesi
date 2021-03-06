using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IProductService
    {
        IList<Product> GetAllProducts();
        IList<Product> GetAllWithLanguage();
        IList<Product> GetAllTR();
        IList<Product> GetAllTR2();
        IList<Product> GetAllENG();
        IList<SubProduct> GetAll();
        IList<Language> GetAllLanguages();
        IList<ProductDescription> GetByProductId(int productId);
        IList<ProductDescription> GetByProductId2(int productId);
        IList<ProductImage> ListProductImagesGetByPath(string path);
        SubProduct GetById(int id);
        IList<ProductVideo> GetVideoByPath(string path);
        ProductImage GetProductImageByPath(string path);
        List<ProductDetailModel> GetAllByTR(string path, int IsSubProdouct);
        List<ProductDetailModel> GetAllByENG(string path, int IsSubProdouct);
        List<ProductImage> GetImages(string path, int IsSubProdouct);
        ProductMainImage GetByPath(string path);
        Product2DImage GetByPath2DImage(string path);
        Product GetProductById(int id);
        ProductVideo GetProductVideoByPath(string path);
        string ProductNameTR(string path);
        string ProductNameENG(string path);
        void AddSubProductDescription(ProductDescription productDescription);
        void DeleteProductDescription(int id);
        void AddProductImage(ProductImage productImage);
        void DeleteProductImage(int id);
        void AddProduct2DImage(Product2DImage product2DImage);
        void DeleteProduct2DImage(int id);
        int GetByPathProduct2DImageCount(string path);
        void UpdateSubProducts(SubProduct subProduct);
        void AddProduct(Product product);
        string ProductNameTR2(string path);
        string ProductNameENG2(string path);
        void UpdateProduct(Product product);
        int CountProduct2DImages(string path);
        void Add2DImageProduct(Product2DImage product2DImage);
        void AddProductVideo(ProductVideo productVideo);
        int CountVideGetByPath(string path);
        void DeleteVideo(ProductVideo productVideo);
        ProductVideo GetProductVideoById(int id);
        IList<ProductMainImage> ListProductProductMainImageGetByPath(string path);
        ProductMainImage GetProductImageById(int id);
        void AddProductImage(ProductMainImage productMainImage);

        int CountMainImageGetByPath(string path);
        void DeleteMainImage(ProductMainImage productMainImage);
        Product GetByProductId3(int id);
        void AddSubProduct(SubProduct subProduct);
        void DeleteProduct(Product product);
        void DeleteSubProduct(SubProduct subProduct);
    }
}
