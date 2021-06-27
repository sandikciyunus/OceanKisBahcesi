﻿using Core.DataAccess.Entity_Framework;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Concrete
{
    public class EfAboutDal:EfEntityRepositoryBase<About>,IAboutDal
    {
        private readonly OceanContext _context;
        public EfAboutDal(OceanContext context) : base(context)
        {
            _context = context;
        }
    }
}
