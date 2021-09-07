using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class Service:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public string Logo { get; set; }
    }
}
