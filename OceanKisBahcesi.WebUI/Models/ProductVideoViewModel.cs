using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class ProductVideoViewModel
    {
        public SubProduct SubProduct { get; set; }
        public Product Product { get; set; }
        public IList<ProductVideo> ProductVideos { get; set; }
    }
}
