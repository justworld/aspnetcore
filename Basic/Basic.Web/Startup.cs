using Basic.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System;

namespace Basic.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //注入配置
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            //返回json日期格式化
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
            });
            //数据库
            services.AddDbContext<Data.Implementing.BasicContext>(options =>
                   options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"], r => r.UseRowNumberForPaging()));
            //cookie
            services.AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            //service
            services.AddScoped<Data.Interface.IDbAccessor, Data.Implementing.DbAccessor>();
            services.AddScoped<Core.IWorkContext, WebCore.WebWorkContext>();
            services.AddScoped<Services.Customers.IAccountService, Services.Customers.AccountService>();
            services.AddScoped<Services.Authentication.IAuthenticationService, Services.Authentication.FormsAuthenticationService>();
            //定时任务
            services.AddTimedJob();
            //session
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            //nlog
            env.ConfigureNLog("nlog.config");
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            LogManager.Configuration.Variables["connectionString"] = Configuration["ConnectionStrings:DefaultConnection"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/PageError");
            }

            app.UseAuthentication();
            app.UseSession();
            //路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //初始化map
            WebCore.AutoMapperInit.Init();
            //读取静态文件，默认wwwroot文件夹
            app.UseStaticFiles();
        }
    }
}
