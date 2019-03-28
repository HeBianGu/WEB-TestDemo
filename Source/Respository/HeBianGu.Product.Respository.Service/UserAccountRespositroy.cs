using HeBianGu.Product.Base.Model;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.Product.Respository.Service
{
    public class UserAccountRespositroy : UserLoggerRepositoryBase<ehc_dv_user>, IUserAccountRespositroy
    {
        public UserAccountRespositroy(DataContext dbcontext, ILogger<UserAccountRespositroy> logger) : base(dbcontext, logger)
        {

        }
    }
}
