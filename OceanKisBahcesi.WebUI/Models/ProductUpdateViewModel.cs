using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public IList<Language> Languages { get; set; }
    }
}
