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
    public class EfServiceDal:EfEntityRepositoryBase<Service>,IServiceDal
    {
        private readonly OceanContext _context;
        public EfServiceDal(OceanContext context) : base(context)
        {
            _context = context;
        }

        public IList<Service> GetAll()
        {
            return _context.Services.Include(p => p.Language).ToList();
        }
    }
}
