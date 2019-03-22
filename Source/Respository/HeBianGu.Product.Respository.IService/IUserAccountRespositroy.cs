using HeBianGu.Product.Base.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.IService
{
    public interface IUserAccountRespositroy
    {
         Task<JCSJ_USEACCOUNT> CheckUserLogin(string userName, string passWord);
    }
}
