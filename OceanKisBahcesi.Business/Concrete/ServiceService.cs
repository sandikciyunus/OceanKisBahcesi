using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class ServiceService:IServiceService
    {
        private IServiceDal _serviceDal;
        public ServiceService(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IList<Service> GetAll()
        {
            return _serviceDal.GetAll();
        }

        public IList<Service> GetAllENG()
        {
            return _serviceDal.GetList(p => p.LanguageId == 2);
        }

        public IList<Service> GetAllTR()
        {
            return _serviceDal.GetList(p => p.LanguageId == 1);
        }

        public Service GetById(int id)
        {
            return _serviceDal.Get(p => p.Id == id);
        }

        public void Update(Service service)
        {
            _serviceDal.Update(service);
        }
    }
}
