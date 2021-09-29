using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class FeatureService:IFeatureService
    {
        private IFeatureDal _featureDal;
        public FeatureService(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public IList<Feature> GetAll()
        {
            return _featureDal.GetAll();
        }

        public IList<Feature> GetAllENG()
        {
            return _featureDal.GetList(p => p.LanguageId == 2);
        }

        public IList<Feature> GetAllTR()
        {
            return _featureDal.GetList(p => p.LanguageId == 1);
        }

        public Feature GetById(int id)
        {
            return _featureDal.Get(p => p.Id == id);
        }

        public void UpdateFeatureImage(Feature feature)
        {
            _featureDal.UpdateFeatureImage(feature);
        }

        public void UpdateFeatureName(Feature feature)
        {
            _featureDal.UpdateFeatureName(feature);
        }
    }
}
