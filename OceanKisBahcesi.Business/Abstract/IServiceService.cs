using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IServiceService
    {
        IList<Service> GetAll();
        IList<Service> GetAllTR();
        IList<Service> GetAllENG();

        Service GetById(int id);
        void Update(Service service);
    }
}
