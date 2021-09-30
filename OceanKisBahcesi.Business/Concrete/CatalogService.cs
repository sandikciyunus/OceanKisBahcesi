using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class CatalogService : ICatalogService
    {
        private ICatalogDal _catalogDal;
        public CatalogService(ICatalogDal catalogDal)
        {
            _catalogDal = catalogDal;
        }
        public IList<Catalog> GetAll()
        {
            return _catalogDal.GetList();
        }
    }
}
