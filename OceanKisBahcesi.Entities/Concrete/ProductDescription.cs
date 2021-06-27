using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class ProductDescription:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Feature { get; set; }
        public string Path { get; set; }
        public string DescriptionName { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int IsSubProduct { get; set; }
    }
}
