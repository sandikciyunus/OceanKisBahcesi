using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public string Path { get; set; }
        public IList<SubProduct> SubProducts { get; set; }
    }
}
