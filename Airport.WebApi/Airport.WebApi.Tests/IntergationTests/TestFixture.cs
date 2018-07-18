namespace Airport.WebApi.Tests.IntergationTests
{
    using System;
    using System.IO;
    using System.Net.Http;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.PlatformAbstractions;

    public class TestFixture : IDisposable
    {
        public TestServer Server { get; }

        public HttpClient Client { get; }

        public TestFixture()
        {   
            // To avoid hardcoding path to project, see: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing#integration-testing
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath, "../../../../../Airport.WebApi/Airport.WebApi"));
            Server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>()
                .UseContentRoot(applicationPath)
                .UseEnvironment("Development"));
            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}
