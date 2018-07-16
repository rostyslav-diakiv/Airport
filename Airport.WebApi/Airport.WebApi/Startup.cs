using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airport.WebApi
{
    using Airport.Common.Validators;
    using Airport.WebApi.Extensions;
    using Airport.WebApi.Utils;

    using AirportEf.BLL.Interfaces;
    using AirportEf.BLL.Mapper;
    using AirportEf.BLL.Services;
    using AirportEf.DAL;
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    using FluentValidation.AspNetCore;

    using Microsoft.EntityFrameworkCore;
    

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
            services.ConfigureSwagger(Configuration);

            services.AddDbContext<AirportDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("AirportEf.DAL")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICrewService, CrewService>();
            services.AddTransient<IDepartureService, DepartureService>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IPilotService, PilotService>();
            services.AddTransient<IPlaneService, PlaneService>();
            services.AddTransient<IPlaneTypeService, PlaneTypeService>();
            services.AddTransient<IStewardessService, StewardessService>();
            services.AddTransient<ITicketService, TicketService>();


            services.AddAutoMapper(cfg =>
                {
                    cfg.AddProfile<CrewsProfile>();
                    cfg.AddProfile<DeparturesProfile>();
                    cfg.AddProfile<FlightsProfile>();
                    cfg.AddProfile<PilotsProfile>();
                    cfg.AddProfile<PlanesProfile>();
                    cfg.AddProfile<PlanesProfile>();
                    cfg.AddProfile<StewardessProfile>();
                    cfg.AddProfile<TicketsProfile>();
                }); // Scoped Lifetime!
            // https://lostechies.com/jimmybogard/2016/07/20/integrating-automapper-with-asp-net-core-di/

            services.AddMvc() // opt => opt.Filters.Add(typeof(ValidatorActionFilter))
                .AddFluentValidation(fv =>
                    {
                        fv.ImplicitlyValidateChildProperties = true;
                      //  fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                        fv.RegisterValidatorsFromAssemblyContaining<CrewValidator>();
                    })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(MvcSetup.JsonSetupAction);
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

            app.UseHttpStatusCodeExceptionMiddleware();
            app.UseConfiguredSwagger();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
