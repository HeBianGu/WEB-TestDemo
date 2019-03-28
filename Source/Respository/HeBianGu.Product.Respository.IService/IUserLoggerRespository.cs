using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.IService
{
    public interface IUserLoggerRespository : IUserLoggerRepositoryBase<ehc_dv_userlogger>
    {

        Task<List<UserLoggerViewModel>> GetLoggers();
        
    }
}
