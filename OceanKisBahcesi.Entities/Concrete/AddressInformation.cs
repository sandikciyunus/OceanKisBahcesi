using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class AddressInformation:IEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
    }
}
