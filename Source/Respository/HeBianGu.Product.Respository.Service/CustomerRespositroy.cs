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
    public class CustomerRespository : UserLoggerRepositoryBase<ehc_dv_customer>, ICustomerRespository
    {
        public CustomerRespository(DataContext dbcontext, ILogger<CustomerRespository> logger) : base(dbcontext, logger)
        {

        }
    }
}
