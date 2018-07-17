using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Airport.WebApi
{
    using System.IO;

    using Airport.WebApi.Extensions;

    using AirportEf.BLL.Utils;
    using AirportEf.DAL.Data;

    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var dir = Directory.GetCurrentDirectory();
            CreateWebHostBuilder(args)
                        .Build()
                        .Migrate<AirportDbContext>(DatabaseSeeder.SeedAction)
                        .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                        config.AddEnvironmentVariables();
                    })
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
