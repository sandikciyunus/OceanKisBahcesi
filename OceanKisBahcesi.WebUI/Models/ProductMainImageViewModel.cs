using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class ProductMainImageViewModel
    {
        public IList<ProductMainImage> ProductMainImages { get; set; }
        public SubProduct SubProduct { get; set; }
        public Product Product { get; set; }
    }
}
