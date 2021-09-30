using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class Catalog:IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
}
