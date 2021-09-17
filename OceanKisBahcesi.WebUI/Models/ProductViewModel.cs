using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IList<ProductDescription> ProductDescriptions { get; set; }
        public Product2DImage Product2DImage { get; set; }
        public int Count2DImages { get; set; }
    }
}
