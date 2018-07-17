namespace Airport.WebApi.Tests.IntergationTests
{
    using System.Net;
    using System.Threading.Tasks;

    using Xunit;

    public class DeletePilotsApiTests : IClassFixture<TestFixture>
    {
        private TestFixture _fixure;
        public DeletePilotsApiTests(TestFixture fixture)
        {
            _fixure = fixture;
        }

        [Fact]
        public async Task DeleteExistingPilot_ReturnsNoContent()
        {
            _fixure.Client.Dispose();
            _fixure.Server.Dispose();
            
            _fixure = new TestFixture();
            // Arrange
            var pilotIdMock = 5;

            // Act
            var response = await _fixure.Client.DeleteAsync($"/api/pilots/{pilotIdMock}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            // Act Again =)
            var getResponse = await _fixure.Client.GetAsync($"/api/pilots/{pilotIdMock}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteNotExistingPilot_ReturnsNotFound()
        {
            // Arrange
            var pilotIdMock = 12341353;

            // Act
            var response = await _fixure.Client.DeleteAsync($"/api/pilots/{pilotIdMock}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
