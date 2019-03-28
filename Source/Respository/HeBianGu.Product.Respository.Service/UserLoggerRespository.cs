using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.IService;
using HeBianGu.Product.Respository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.Service
{
    public class UserLoggerRespository : UserLoggerRepositoryBase<ehc_dv_userlogger>, IUserLoggerRespository
    {
        public UserLoggerRespository(DataContext dbcontext, ILogger<UserLoggerRespository> logger) : base(dbcontext, logger)
        {

        }

        public async Task<List<UserLoggerViewModel>> GetLoggers()
        {
            var collection = await this.GetListAsync();

            List<UserLoggerViewModel> result = new List<UserLoggerViewModel>();

            foreach (var item in collection)
            {
                UserLoggerViewModel viewModel = new UserLoggerViewModel();

                viewModel.User = await this._dbContext.Users.FindAsync(item.USERID);

                viewModel.TIME = item.TIME;

                viewModel.MESSAGE = item.MESSAGE;

                viewModel.TYPE = item.TYPE;

                result.Add(viewModel);

            }

            return result;
        }
    }
}
