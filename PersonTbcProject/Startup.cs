using ApplicationDomainCore;
using ApplicationDomainCore.Abstraction;
using ApplicationDomainEntity.Db;
using ApplicationUIServices.Mapper;
using ApplicationUIServices.PhotoService;
using ApplicationUIServices.PhotoService.Abstraction;
using AutoMapper;
using ExceptionLoggerMIddlware.Models;
using ExceptionLoggerMIddlware.Services;
using ExceptionLoggerMIddlware.Services.Abstraction;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PersonTbcProject
{
    public static class ExceptionHandlerExtencion
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogService logger)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async errorContext =>
                {
                    errorContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorContext.Response.ContentType = "application/json";
                    var contextFeature = errorContext.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Something went wrong: {contextFeature.Error}");

                        await errorContext.Response.WriteAsync(new ErrorInformation()
                        {
                            StatusCode = errorContext.Response.StatusCode,
                            Message = "Internal Server Error. Error generated by NLog!"
                        }.ToString());
                    }

                });
            });
        }
    }
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
            services.AddSingleton<ILogService, LogService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("PersonApp", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Persons Open Source Api",
                    Version = "4",
                    Description = "Persons App Api",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "Abesadzegiorgi2004@gmail.com",
                        Name = "Abesadze Giorgi"
                    }
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogService logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/PersonApp/swagger.json", "PersonApp App Api");
                options.RoutePrefix = "";
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
