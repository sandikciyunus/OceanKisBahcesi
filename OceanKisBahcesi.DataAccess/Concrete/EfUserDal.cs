using Core.DataAccess.Entity_Framework;
using OceanKisBahcesi.DataAccess.Abstract;
using OceanKisBahcesi.DataAccess.Concrete.Context;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Concrete
{
    public class EfUserDal:EfEntityRepositoryBase<User>,IUserDal
    {
        private OceanContext _context;
        public EfUserDal(OceanContext context):base(context)
        {
            _context = context;
        }

        public bool CheckUser(string userName, string password)
        {
            var user = _context.Users.Where(p => p.Username == userName && p.Password == password).FirstOrDefault();

            return user != null;
        }
    }
}
