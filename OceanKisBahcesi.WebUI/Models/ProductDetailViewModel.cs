using OceanKisBahcesi.Entities.Concrete;
using OceanKisBahcesi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public List<ProductDetailModel> ProductDetails { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public IList<ProductVideo> ProductVideos { get; set; }
        public ProductMainImage MainImage { get; set; }
        public Product2DImage Product2DImage { get; set; }
        public string SubProductName { get; set; }
    }
}
