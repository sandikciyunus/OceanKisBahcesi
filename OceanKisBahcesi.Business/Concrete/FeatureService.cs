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

        public IList<Feature> GetAllENG()
        {
            return _featureDal.GetList(p => p.LanguageId == 2);
        }

        public IList<Feature> GetAllTR()
        {
            return _featureDal.GetList(p => p.LanguageId == 1);
        }
    }
}
