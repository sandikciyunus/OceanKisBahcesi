using OceanKisBahcesi.Business.Abstract;
using OceanKisBahcesi.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Concrete
{
    public class UserService:IUserService
    {
        private IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool CheckUser(string userName, string password)
        {
            return _userDal.CheckUser(userName, password);
        }
    }
}
