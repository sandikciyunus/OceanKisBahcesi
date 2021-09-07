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

        public IList<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public IList<About> GetAllENG()
        {
            return _aboutDal.GetList(p => p.LanguageId == 2);
        }

        public IList<About> GetAllTR()
        {
            return _aboutDal.GetList(p => p.LanguageId == 1);
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(p => p.Id == id);
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
