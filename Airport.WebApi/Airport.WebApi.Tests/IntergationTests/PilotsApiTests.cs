namespace Airport.WebApi.Tests.IntergationTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.WebApi.Tests.Extensions;

    using Xunit;

    public class PilotsApiTests : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixure;
        public PilotsApiTests(TestFixture fixture)
        {
            _fixure = fixture;
        }

        [Fact]
        public async Task GetPilots_Returns_5_PilotDtos()
        {
            // Arrange
            var pilotsCount = 5;

            // Act
            var response = await _fixure.Client.GetAsync("/api/pilots");

            // Assert
            response.EnsureSuccessStatusCode();
            var pilotDtos = await response.Content.ReadAsJsonAsync<List<PilotDto>>();
            Assert.Equal(pilotsCount, pilotDtos.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task GetExistingPilotById_2And4_ReturnsPilotDtoWith_2And4_Id(int id)
        {
            // Act
            var response = await _fixure.Client.GetAsync($"/api/pilots/{id}");

            // Assert
            //  Assert.Contains(PredefinedData.Articles[0].Contents, responseString);
            response.EnsureSuccessStatusCode();
            var pilotDto = await response.Content.ReadAsJsonAsync<PilotDto>();
            Assert.Equal(id, pilotDto.Id);
        }

        [Theory]
        [InlineData(119)]
        [InlineData(-119)]
        public async Task GetUnExistingPilotById_7And9_ReturnsPilotDtoWith_7And9_Id(int id)
        {
            // Act
            var response = await _fixure.Client.GetAsync($"/api/pilots/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task UpdatePilot_WhenRequestIsValid_ReturnsNoContent()
        {
            // Arrange
            var pilotIdMock = 2;
            var pilot = new PilotRequest()
            {
                Name = "TestUpdate",
                FamilyName = "UpdateTest",
                DateOfBirth = new DateTime(1998, 12, 2),
                Experience = new TimeSpan(1000, 0, 0)
            };

            // Act
            var response = await _fixure.Client.PutAsJsonAsync($"/api/pilots/{pilotIdMock}", pilot);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            // Act Again =)
            var getResponse = await _fixure.Client.GetAsync($"/api/pilots/{pilotIdMock}");

            // Assert
            getResponse.EnsureSuccessStatusCode();
            var pilotDto = await getResponse.Content.ReadAsJsonAsync<PilotDto>();
            Assert.Equal(pilot.Name, pilotDto.Name);
            Assert.Equal(pilot.DateOfBirth, pilotDto.DateOfBirth);
        }

        [Fact]
        public async Task UpdatePilot_WhenRequestIsInValid_ReturnsBadRequest()
        {
            // Arrange
            var pilotIdMock = 2;
            var pilot = new PilotRequest()
            {
                Name = "TestCreate",
                FamilyName = "CreateTest",
                DateOfBirth = new DateTime(2005, 12, 2),
                Experience = new TimeSpan(1000, 0, 0)
            };

            // Act
            var response = await _fixure.Client.PutAsJsonAsync($"/api/pilots/{pilotIdMock}", pilot);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateNotExistingPilot_WhenRequestIsValid_ReturnsNoFound()
        {
            // Arrange
            var pilotIdMock = 123123123;
            var pilot = new PilotRequest()
            {
                Name = "TestCreate",
                FamilyName = "CreateTest",
                DateOfBirth = new DateTime(1996, 12, 2),
                Experience = new TimeSpan(1000, 0, 0)
            };

            // Act
            var response = await _fixure.Client.PutAsJsonAsync($"/api/pilots/{pilotIdMock}", pilot);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // [Collection("Common Server Collection")] // TODO: Will be the same server as the Get
        //public class DeletePilotsApiTests : IClassFixture<TestFixture>
        //{
        //    private readonly TestFixture _fixure;
        //    public DeletePilotsApiTests(TestFixture fixture)
        //    {
        //        _fixure = fixture;
        //    }

        //    [Fact]
        //    public async Task DeleteExistingPilot_ReturnsNoContent()
        //    {
        //        // Arrange
        //        var pilotIdMock = 5;

        //        // Act
        //        var response = await _fixure.Client.DeleteAsync($"/api/pilots/{pilotIdMock}");

        //        // Assert
        //        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        //        // Act Again =)
        //        var getResponse = await _fixure.Client.GetAsync($"/api/pilots/{pilotIdMock}");

        //        // Assert
        //        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        //    }

        //    [Fact]
        //    public async Task DeleteNotExistingPilot_ReturnsNotFound()
        //    {
        //        // Arrange
        //        var pilotIdMock = 12341353;

        //        // Act
        //        var response = await _fixure.Client.DeleteAsync($"/api/pilots/{pilotIdMock}");

        //        // Assert
        //        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        //    }
        //}

        //[Collection("Common Server Collection")] // TODO: Will be the same server as the Get
        //public class CreatePilotsApiTests
        //{
        //    private readonly TestFixture _fixure;
        //    public CreatePilotsApiTests(TestFixture fixture)
        //    {
        //        _fixure = fixture;
        //    }

        //    [Fact]
        //    public async Task CreatePilot_WhenRequestIsValid_ReturnsCreatedPilotDto()
        //    {
        //        // Arrange
        //        var pilot = new PilotRequest()
        //        {
        //            Name = "TestCreate",
        //            FamilyName = "CreateTest",
        //            DateOfBirth = new DateTime(1998, 12, 2),
        //            Experience = new TimeSpan(1000, 0, 0)
        //        };

        //        // Act
        //        var response = await _fixure.Client.PostAsJsonAsync("/api/pilots", pilot);

        //        // Assert
        //        response.EnsureSuccessStatusCode();
        //        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        //        var pilotDto = await response.Content.ReadAsJsonAsync<PilotDto>();

        //        Assert.Equal(pilot.Name, pilotDto.Name);
        //        Assert.Equal(pilot.FamilyName, pilotDto.FamilyName);
        //        Assert.True(pilotDto.Id > 0);
        //        Assert.Equal($"/api/Pilots/{pilotDto.Id}", response.Headers.Location.LocalPath);
        //    }

        //    [Fact]
        //    public async Task CreatePilot_WhenRequestIsInValid_ReturnsBadRequest()
        //    {
        //        // Arrange
        //        var pilot = new PilotRequest()
        //        {
        //            Name = "TestCreate",
        //            FamilyName = "CreateTest",
        //            DateOfBirth = new DateTime(2005, 12, 2),
        //            Experience = new TimeSpan(1000, 0, 0)
        //        };

        //        // Act
        //        var response = await _fixure.Client.PostAsJsonAsync("/api/pilots", pilot);

        //        // Assert
        //        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //    }
        //}
    }
}
