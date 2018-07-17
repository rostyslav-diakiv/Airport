﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airport.WebApi.Tests.IntergationTests
{
    using System;
    using System.Diagnostics;

    using AirportEf.BLL.Utils;
    using AirportEf.DAL.Data;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            Mapper.Reset();
            base.ConfigureServices(services);
        }

        public override void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            // Replace default database connection string to Test Db connection
            services.AddDbContext<AirportDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TestConnection"),
                    b => b.MigrationsAssembly(configuration["MigrationsAssembly"])));

            // Replace default database connection with In-Memory database
            //services.AddDbContext<AirportDbContext>(options =>
            //             options.UseInMemoryDatabase("airport_test_db"));
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Perform all the configuration in the base class
            base.Configure(app, env);

            // Now seed the database
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AirportDbContext>();
                try
                {
                    context?.Database?.Migrate();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                   // context?.Database?.EnsureDeleted();
                    //context?.Database?.Migrate();
                }

                DatabaseSeeder.SeedAction(context);
            }
        }
    }
}