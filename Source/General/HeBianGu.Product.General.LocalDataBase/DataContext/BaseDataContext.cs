using HeBianGu.Product.Base.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeBianGu.Product.General.LocalDataBase
{
    /// <summary> 增加一个泛型集合 </summary>
    public class BaseDataContext<T> : DataContext where T : class
    {

        public BaseDataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary> 泛型集合 </summary>
        public DbSet<T> Collection { get; set; }
    }
}
