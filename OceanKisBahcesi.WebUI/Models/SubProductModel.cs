using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class SubProductModel
    {
        public SubProduct SubProduct { get; set; }
        public IList<Product> Products { get; set; }
    }
}
