using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeBianGu.Product.General.LocalDataBase
{
    class BaseDataContext<T> : DbContext where T : class
    { 
        public DbSet<T> Collection { get; set; }
    }
}
