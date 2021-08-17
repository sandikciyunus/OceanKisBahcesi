using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class Slider:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
    }
}
