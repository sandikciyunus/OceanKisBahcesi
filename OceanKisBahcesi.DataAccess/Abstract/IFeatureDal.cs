using Core.DataAcces;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Abstract
{
    public interface IFeatureDal:IEntityRepository<Feature>
    {
        IList<Feature> GetAll();
        void UpdateFeatureImage(Feature feature);
        void UpdateFeatureName(Feature feature);
    }
}
