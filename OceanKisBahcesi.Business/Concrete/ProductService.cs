using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class ProductService:IProductService
    {
        private IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<ProductDetailModel> GetAllByENG(string path, int IsSubProdouct)
        {
            return _productDal.GetAllByENG(path, IsSubProdouct);
        }

        public List<ProductDetailModel> GetAllByTR(string path, int IsSubProdouct)
        {
            return _productDal.GetAllByTR(path, IsSubProdouct);
        }

        public IList<Product> GetAllENG()
        {
            return _productDal.GetAllENG();
        }

        public IList<Product> GetAllTR()
        {
            return _productDal.GetAllTR();
        }

        public IList<Product> GetAllTR2()
        {
            return _productDal.GetList(p => p.LanguageId == 1);
        }

        public ProductMainImage GetByPath(string path)
        {
            return _productDal.GetByPath(path);
        }

        public Product2DImage GetByPath2DImage(string path)
        {
            return _productDal.GetByPath2DImage(path);
        }

        public List<ProductImage> GetImages(string path, int IsSubProdouct)
        {
            return _productDal.GetImages(path, IsSubProdouct);
        }

        public IList<ProductVideo> GetVideoByPath(string path)
        {
            return _productDal.GetVideoByPath(path);
        }

        public string ProductNameENG(string path)
        {
            return _productDal.ProductNameENG(path);
        }

        public string ProductNameTR(string path)
        {
            return _productDal.ProductNameTR(path);
        }
    }
}
