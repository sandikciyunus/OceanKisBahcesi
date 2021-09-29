using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IFeatureService
    {
        IList<Feature> GetAll();
        IList<Feature> GetAllTR();
        IList<Feature> GetAllENG();
        Feature GetById(int id);
        void UpdateFeatureImage(Feature feature);
        void UpdateFeatureName(Feature feature);
    }
}
