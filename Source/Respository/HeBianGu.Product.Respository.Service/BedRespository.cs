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
    public class BedRespositroy : UserLoggerRepositoryBase<ehc_dv_bed>, IBedRespository
    {
        public BedRespositroy(DataContext dbcontext, ILogger<BedRespositroy> logger) : base(dbcontext, logger)
        {

        }
    }
}
