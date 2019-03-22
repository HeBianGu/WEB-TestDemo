using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HeBianGu.Prodoct.Domain.DataServce;
using HeBianGu.Product.General.LocalDataBase;
using HeBianGu.Product.Respository.IService;
using HeBianGu.Product.Respository.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HeBianGu.Product.WebApp.Demo
{
    public class Startup
    {

        ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;

            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("Step ConfigureServices");

            //  Do：获取数据库连接字符串
            string cs = this.Configuration.GetConnectionString("MySqlConnection");

            //  Do：注册数据上下文
            services.AddDbContextWithConnectString<DataContext>(cs); 

            //  Do：依赖注入
            services.AddScoped<IUserAccountRespositroy, UserAccountRespositroy>();

            //  Message：注册内服务领域模型
            //services.AddScoped<TestService>();

            //services.AddTransient(l => new HomeControler(new TestServer("fdfdd"))); 

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //  Message：注册过滤器
            //services.AddMvc(l=>l.Filters.Add(new SamepleGlobalActionFilter())) ;

            //  Do：注册日志
            var loggingConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("logging.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddLogging(builder =>
            {
                builder
                    .AddConfiguration(loggingConfiguration.GetSection("Logging"))
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("HeBianGu.Product.WebApp.Demo", LogLevel.Debug)
                    .AddConsole();
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //  Do：注册日志

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}"); 
            });

        

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=User}/{action=Index}/{id?}");
            //});
        }
    }
}
