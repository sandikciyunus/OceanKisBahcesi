using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class Feature:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int LanguageId { get; set; }
        public int Sort { get; set; }
    }
}
