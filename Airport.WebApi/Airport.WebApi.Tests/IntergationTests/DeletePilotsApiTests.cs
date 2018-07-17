namespace Airport.WebApi.Tests.IntergationTests
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.PlatformAbstractions;

    using Xunit;

    public class DeletePilotsApiTests // : IClassFixture<TestFixture>
    {
        public TestServer Server { get; }
        public HttpClient Client { get; }

        // private TestFixture _fixure;
        public DeletePilotsApiTests(/*TestFixture fixture*/)
        {
            // To avoid hardcoding path to project, see: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing#integration-testing
            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath; // integration_tests/bin/Debug/netcoreapp2.0
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath, "../../../../../Airport.WebApi/Airport.WebApi"));
            // "E:\\TernopilCourses\\BinaryStudion\\Airport\\Airport.WebApi\\Airport.WebApi"
            Server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>()
                .UseContentRoot(applicationPath)
                .UseEnvironment("Development"));
            Client = Server.CreateClient();
            // _fixure = fixture;
        }
        
        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }

        [Fact]
        public async Task DeleteExistingPilot_ReturnsNoContent()
        {
            // Arrange
            var pilotIdMock = 5;

            // Act
            var response = await Client.DeleteAsync($"/api/pilots/{pilotIdMock}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            // Act Again =)
            var getResponse = await Client.GetAsync($"/api/pilots/{pilotIdMock}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteNotExistingPilot_ReturnsNotFound()
        {
            // Arrange
            var pilotIdMock = 12341353;

            // Act
            var response = await Client.DeleteAsync($"/api/pilots/{pilotIdMock}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
