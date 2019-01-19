using HeBianGu.Product.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HeBianGu.Product.General.LocalDataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(SystemSet.MysqlConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public static void Init(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseMySQL(SystemSet.MysqlConnectionString));
        }


        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<JCSJ_USEACCOUNT> Users { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<jw_add_data> Datas { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<JCSJ_CUSTOMER> Customers { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<JCSJ_BED> Beds { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<JCSJ_MAT> Mats { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<JCSJ_MONITOR> Moniters { get; set; }

    }
}
