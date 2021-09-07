using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IFeatureService
    {
        IList<Feature> GetAllTR();
        IList<Feature> GetAllENG();
    }
}
