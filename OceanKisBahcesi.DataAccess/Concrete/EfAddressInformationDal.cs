using Core.DataAccess.Entity_Framework;
using Microsoft.EntityFrameworkCore;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Concrete
{
    public class EfAddressInformationDal: EfEntityRepositoryBase<AddressInformation>, IAdressInformationDal
    {
        private readonly OceanContext _context;
        public EfAddressInformationDal(OceanContext context) : base(context)
        {
            _context = context;
        }

        public IList<AddressInformation> GetAll()
        {
            return _context.AddressInformations.Include(p => p.Language).ToList();
        }
    }
}
