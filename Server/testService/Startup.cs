using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using testService.Model;

namespace testService
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

            services.AddCors(option => option.AddPolicy("_AllowSpecificOrigins"
                    , policy => policy.AllowAnyHeader()
                        .SetIsOriginAllowed(_ => true)  //准许所有跨域
                        .AllowAnyMethod()
                        .AllowCredentials()
                        //.AllowAnyOrigin()
                        //.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")
                        //.WithOrigins(new[] { "http://localhost:8080/" }) //后续配置
               )
            );



            var connection = Configuration.GetConnectionString("DataContext");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "zmy--API",
                    Contact = new OpenApiContact
                    {
                        Name = "zmy",
                        Email = string.Empty,
                        Url = new Uri("https://www.cnblogs.com/zaranet")

                    },
                    License = new OpenApiLicense
                    {
                        Name = "许可证名字",
                        Url = new Uri("https://www.cnblogs.com/zaranet")
                    }
                }
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("_AllowSpecificOrigins");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
