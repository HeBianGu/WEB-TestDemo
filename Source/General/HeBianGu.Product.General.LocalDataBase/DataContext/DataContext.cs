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

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<ehc_dv_user> Users { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<jw_add_data> Datas { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<ehc_dv_customer> Customers { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<ehc_dv_bed> Beds { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<JCSJ_MAT> Mats { get; set; }

        /// <summary>
        /// 报表数据
        /// </summary>
        public DbSet<ehc_dv_monitor> Moniters { get; set; }

        /// <summary>
        /// 监控项扩展
        /// </summary>
        public DbSet<ehc_dv_monitorextention> ehc_dv_monitorextentions { get; set; }

        /// <summary>
        /// 监控项类型表
        /// </summary>
        public DbSet<ehc_dv_monitortype> ehc_dv_monitortypes { get; set; }

        /// <summary>
        /// 用户操作日志
        /// </summary>
        public DbSet<ehc_dv_userlogger> ehc_dv_userloggers { get; set; }


        /// <summary>
        /// 报警记录
        /// </summary>
        public DbSet<ehc_dv_warn> ehc_dv_warns { get; set; }


    }
}
