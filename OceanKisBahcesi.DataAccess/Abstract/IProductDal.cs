using Core.DataAcces;
using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        IList<Product> GetAllENG();
        IList<Product> GetAllTR();
        IList<Product> GetAllWithLanguage();
        IList<SubProduct> GetAll();
        IList<Language> GetAllLanguages();
        SubProduct GetById(int id);
        IList<ProductDescription> GetByProductId(int productId);
        IList<ProductDescription> GetByProductId2(int productId);
        IList<ProductImage> ListProductImagesGetByPath(string path);
        ProductMainImage GetByPath(string path);
        ProductImage GetProductImageByPath(string path);
        Product2DImage GetByPath2DImage(string path);
        List<ProductDetailModel> GetAllByTR(string path, int IsSubProdouct);
        List<ProductDetailModel> GetAllByENG(string path, int IsSubProdouct);
        List<ProductImage> GetImages(string path, int IsSubProdouct);
        IList<ProductVideo> GetVideoByPath(string path);
        string ProductNameTR(string path);
        string ProductNameENG(string path);

        string ProductNameTR2(string path);
        string ProductNameENG2(string path);
        void AddSubProductDescription(ProductDescription productDescription);
        void DeleteProductDescription(int id);

        void AddProductImage(ProductImage productImage);
        void DeleteProductImage(int id);

        void AddProduct2DImage(Product2DImage product2DImage);
        void DeleteProduct2DImage(int id);

        int GetByPathProduct2DImageCount(string path);

        void UpdateSubProducts(SubProduct subProduct);
        void UpdateProducts(Product product);
        int CountProduct2DImages(string path);

    }
}
