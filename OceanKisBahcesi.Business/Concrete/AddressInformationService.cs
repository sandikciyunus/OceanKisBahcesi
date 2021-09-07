using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class AddressInformationService : IAddressInformationService
    {
        private IAdressInformationDal _addressInformationDal;
        public AddressInformationService(IAdressInformationDal adressInformationDal)
        {
            _addressInformationDal = adressInformationDal;
        }

        public IList<AddressInformation> GetAll()
        {
            return _addressInformationDal.GetAll();
        }

        public AddressInformation GetAllENG()
        {
            return _addressInformationDal.Get(p => p.LanguageId == 2);
        }

        public AddressInformation GetAllTR()
        {
            return _addressInformationDal.Get(p => p.LanguageId == 1);
        }

        public AddressInformation GetById(int id)
        {
            return _addressInformationDal.Get(p => p.Id == id);
        }

        public void Update(AddressInformation addressInformation)
        {
            _addressInformationDal.Update(addressInformation);
        }
    }
}
