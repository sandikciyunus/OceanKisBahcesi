using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Entities.Concrete
{
    public class About: IEntity
    {
        public int Id { get; set; }
        public string AboutDescription { get; set; }
        public string OurVisionDescription { get; set; }
        public string OurMission { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
    }
}
