using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.Service
{
    public class UserAccountRespositroy : RepositoryBase<JCSJ_USEACCOUNT>, IUserAccountRespositroy
    {

        public UserAccountRespositroy(DataContext dbcontext,ILogger<UserAccountRespositroy> logger) : base(dbcontext, logger)
        {

        }

        /// <summary> 获取用户 </summary>
        public async Task<JCSJ_USEACCOUNT> CheckUserLogin(string userName, string passWord)
        {

            this._logger.LogInformation($"CheckUserLogin:{userName}-{passWord}");

            //   var jCSJ_MONITOR = await _context.Moniters
            //.FirstOrDefaultAsync(m => m.ID == id);

            return await _dbContext.Set<JCSJ_USEACCOUNT>().FirstOrDefaultAsync(l => l.NAME == userName && l.PASSWORD == passWord);

            //return await _dbContext.Set<JCSJ_USEACCOUNT>().FirstOrDefault(l => l.NAME == userName && l.PASSWORD == passWord);

        }
    }
}
