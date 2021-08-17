using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IServiceService
    {
        IList<Service> GetAllTR();
        IList<Service> GetAllENG();
    }
}
