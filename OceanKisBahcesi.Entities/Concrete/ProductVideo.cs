using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class ProductVideo:IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
    }
}
