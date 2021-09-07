using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanKisBahcesi.WebUI.Models
{
    public class HomeViewModel
    {
        public IList<Slider> Sliders { get; set; }
        public IList<Service> Services { get; set; }
        public IList<HomeVideo> HomeVideos { get; set; }
        public IList<Feature> Features { get; set; }
    }
}
