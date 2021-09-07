using Core.DataAcces;
using OceanKisBahcesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        bool CheckUser(string userName, string password);
    }
}
