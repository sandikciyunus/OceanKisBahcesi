using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class HomeVideo:IEntity
    {
        public int Id { get; set; }
        public string VideoName { get; set; }
    }
}
