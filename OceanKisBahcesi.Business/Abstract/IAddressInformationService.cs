using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IAddressInformationService
    {
        AddressInformation GetById(int id);
        IList<AddressInformation> GetAll();
        AddressInformation GetAllTR();
        AddressInformation GetAllENG();
        void Update(AddressInformation addressInformation);
    }
}
