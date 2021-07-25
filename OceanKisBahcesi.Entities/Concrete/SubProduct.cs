using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class SubProduct:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public string Path { get; set; }
    }
}
