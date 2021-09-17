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

        public void AddSubProductDescription(ProductDescription productDescription)
        {
            _productDal.AddSubProductDescription(productDescription);
        }

        public IList<SubProduct> GetAll()
        {
            return _productDal.GetAll();
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

        public SubProduct GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public IList<ProductDescription> GetByProductId(int productId)
        {
            return _productDal.GetByProductId(productId);
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

        public void DeleteProductDescription(int id)
        {
            _productDal.DeleteProductDescription(id);
        }

        public IList<ProductImage> ListProductImagesGetByPath(string path)
        {
            return _productDal.ListProductImagesGetByPath(path);
        }

        public ProductImage GetProductImageByPath(string path)
        {
            return _productDal.GetProductImageByPath(path);
        }

        public void AddProductImage(ProductImage productImage)
        {
            _productDal.AddProductImage(productImage);
        }

        public void DeleteProductImage(int id)
        {
            _productDal.DeleteProductImage(id);
        }

        public void AddProduct2DImage(Product2DImage product2DImage)
        {
            _productDal.AddProduct2DImage(product2DImage);
        }

        public void DeleteProduct2DImage(int id)
        {
            _productDal.DeleteProduct2DImage(id);
        }

        public int GetByPathProduct2DImageCount(string path)
        {
            return _productDal.GetByPathProduct2DImageCount(path);
        }

        public IList<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }

        public void UpdateSubProducts(SubProduct subProduct)
        {
            _productDal.UpdateSubProducts(subProduct);
        }

        public IList<Product> GetAllWithLanguage()
        {
            return _productDal.GetAllWithLanguage();
        }

        public void AddProduct(Product product)
        {
            _productDal.Add(product);
        }

        public IList<Language> GetAllLanguages()
        {
            return _productDal.GetAllLanguages();
        }

        public string ProductNameTR2(string path)
        {
            return _productDal.ProductNameTR2(path);
        }

        public string ProductNameENG2(string path)
        {
            return _productDal.ProductNameENG2(path);
        }

        public Product GetProductById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            _productDal.UpdateProducts(product);
        }

        public IList<ProductDescription> GetByProductId2(int productId)
        {
            return _productDal.GetByProductId2(productId);
        }

        public int CountProduct2DImages(string path)
        {
            return _productDal.CountProduct2DImages(path);
        }
    }
}
