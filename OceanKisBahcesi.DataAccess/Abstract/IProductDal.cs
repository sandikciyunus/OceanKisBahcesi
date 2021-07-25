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
        IList<SubProduct> GetAll();
        SubProduct GetById(int id);
        IList<ProductDescription> GetByProductId(int productId);
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
        void AddSubProductDescription(ProductDescription productDescription);
        void DeleteProductDescription(int id);

        void AddProductImage(ProductImage productImage);
        void DeleteProductImage(int id);
    }
}
