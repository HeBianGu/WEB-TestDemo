using CDTY.DataAnalysis.Entity;
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL(SystemSet.MysqlConnectionString);

        //    base.OnConfiguring(optionsBuilder);

        //}

        //public static void Init(IServiceCollection services)
        //{
        //    services.AddDbContext<DataContext>(options => options.UseMySQL(SystemSet.MysqlConnectionString));
        //}


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

        /// <summary>
        /// 缺陷数据
        /// </summary>
        public DbSet<TyeEncodeDeviceEntity> TyeEncodeDeviceEntitys { get; set; }

        /// <summary>
        /// 监控项扩展
        /// </summary>
        public DbSet<ehc_dv_monitorextention> ehc_dv_monitorextentions { get; set; }

        /// <summary>
        /// 监控项类型表
        /// </summary>
        public DbSet<ehc_dv_monitortype> ehc_dv_monitortypes { get; set; }


    }
}
