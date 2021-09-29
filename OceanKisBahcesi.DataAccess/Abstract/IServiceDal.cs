using Core.DataAcces;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Abstract
{
    public interface IServiceDal:IEntityRepository<Service>
    {
        IList<Service> GetAll();
    }
}
