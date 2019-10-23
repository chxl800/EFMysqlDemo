using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFMysqlNetCodeMvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace EFMysqlNetCodeMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //json格式化
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                //忽略循环引用
                //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                //设置序列化时key为驼峰样式,开头字母小写输出  controller调用Josn(对象)
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //原样输出
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                //时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //空值的字段不显示
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            //ef mysql 配置IOC
            services.AddDbContext<DBEntities>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // 跨域策略
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}