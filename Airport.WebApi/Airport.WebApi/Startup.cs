using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airport.WebApi
{
    using Airport.BLL.Interfaces;
    using Airport.BLL.Mapper;
    using Airport.BLL.Services;
    using Airport.DAL;
    using Airport.DAL.Interfaces;
    using Airport.DAL.Interfaces.Repositories;
    using Airport.DAL.Repositories;
    using Airport.WebApi.Extensions;

    using AutoMapper;

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
            services.AddCors(o => o.AddPolicy("Policy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));

            services.ConfigureSwagger(Configuration);

            services.AddSingleton<IDataProvider, DataProvider>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IStewardessService, StewardessService>();
            services.AddTransient<ICrewService, CrewService>();

            services.AddAutoMapper(cfg => cfg.AddProfile(typeof(MappingProfile))); // Scoped Lifetime!
            // https://lostechies.com/jimmybogard/2016/07/20/integrating-automapper-with-asp-net-core-di/

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("Policy");

            app.UseHttpStatusCodeExceptionMiddleware();
            app.UseConfiguredSwagger();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
