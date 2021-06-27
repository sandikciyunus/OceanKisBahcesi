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
        IList<ProductVideo> GetVideoByPath(string path);
        List<ProductDetailModel> GetAllByTR(string path, int IsSubProdouct);
        List<ProductDetailModel> GetAllByENG(string path, int IsSubProdouct);
        List<ProductImage> GetImages(string path, int IsSubProdouct);
        ProductMainImage GetByPath(string path);
        Product2DImage GetByPath2DImage(string path);
        string ProductNameTR(string path);
        string ProductNameENG(string path);
    }
}
