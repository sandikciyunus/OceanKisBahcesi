using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class ProductImageViewModel
    {
        public ProductImage ProductImage { get; set; }
        public IList<ProductImage> ProductImages { get; set; }
    }
}
