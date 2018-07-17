namespace Airport.WebApi.Tests.IntergationTests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.WebApi.Tests.Extensions;

    using Xunit;

    public class DeletePilotsApiTests : IClassFixture<TestFixture>
    {
        private TestFixture _fixure;
        public DeletePilotsApiTests(TestFixture fixture)
        {
           _fixure = fixture;
        }
        
        public void Dispose()
        {
            _fixure.Client.Dispose();
            _fixure.Server.Dispose();
        }

        [Fact]
        public async Task DeleteExistingPilot_ReturnsNoContent()
        {
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

        [Fact]
        public async Task CreatePilot_WhenRequestIsValid_ReturnsCreatedPilotDto()
        {
            // Arrange
            var pilot = new PilotRequest()
            {
                Name = "TestCreate",
                FamilyName = "CreateTest",
                DateOfBirth = new DateTime(1998, 12, 2),
                Experience = new TimeSpan(1000, 0, 0)
            };

            // Act
            var response = await _fixure.Client.PostAsJsonAsync("/api/pilots", pilot);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var pilotDto = await response.Content.ReadAsJsonAsync<PilotDto>();

            Assert.Equal(pilot.Name, pilotDto.Name);
            Assert.Equal(pilot.FamilyName, pilotDto.FamilyName);
            Assert.True(pilotDto.Id > 0);
            Assert.Equal($"/api/Pilots/{pilotDto.Id}", response.Headers.Location.LocalPath);
        }

        [Fact]
        public async Task CreatePilot_WhenRequestIsInValid_ReturnsBadRequest()
        {
            // Arrange
            var pilot = new PilotRequest()
            {
                Name = "TestCreate",
                FamilyName = "CreateTest",
                DateOfBirth = new DateTime(2005, 12, 2),
                Experience = new TimeSpan(1000, 0, 0)
            };

            // Act
            var response = await _fixure.Client.PostAsJsonAsync("/api/pilots", pilot);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
