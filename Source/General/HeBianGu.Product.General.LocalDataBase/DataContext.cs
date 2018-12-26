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
        public DbSet<JCSJ_USEACCOUNT> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(SystemSet.MysqlConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public static void Init(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseMySQL(SystemSet.MysqlConnectionString));
        }
    }
}
