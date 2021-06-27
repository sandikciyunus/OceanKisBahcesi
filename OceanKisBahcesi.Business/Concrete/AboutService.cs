using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class AboutService:IAboutService
    {
        private IAboutDal _aboutDal;
        public AboutService(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IList<About> GetAllENG()
        {
            return _aboutDal.GetList(p => p.LanguageId == 2);
        }

        public IList<About> GetAllTR()
        {
            return _aboutDal.GetList(p => p.LanguageId == 1);
        }
    }
}
