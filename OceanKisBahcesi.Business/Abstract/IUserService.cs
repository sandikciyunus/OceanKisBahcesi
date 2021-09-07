using System;
using System.Collections.Generic;
using System.Text;

namespace OceanKisBahcesi.Business.Abstract
{
    public interface IUserService
    {
        bool CheckUser(string userName, string password);
    }
}
