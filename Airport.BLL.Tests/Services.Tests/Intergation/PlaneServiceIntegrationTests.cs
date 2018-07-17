namespace Airport.BLL.Tests.Services.Tests.Intergation
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Services;

    using Xunit;
    
    [Collection("Common Integration Collection")]
    public class PlaneServiceIntegrationTests
    {
        private readonly IntegrationFixture _integrationFixture;

        public PlaneServiceIntegrationTests(IntegrationFixture integrationFixture)
        {
            _integrationFixture = integrationFixture;
        }
        
        [Fact]
        public async Task CreatePilot_WhenEntityIsValid_AndPlaneTypeExists_ReturnsPlaneDto()
        {
            // Arrange
            var plane = new PlaneRequest()
            {
                Name = "TestCreate",
                PlaneTypeId = 2,
                LifeTime = new TimeSpan(11000, 0, 0),
                CreationDate = new DateTime(1998, 12, 2)
            };

            var planeServie = new PlaneService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act
            var pilotDto = await planeServie.CreateEntityAsync(plane);

            // Assert
            Assert.Equal(plane.Name, pilotDto.Name);
            Assert.Equal(plane.LifeTime, pilotDto.LifeTime);
            Assert.True(pilotDto.Id > 0);
        }

        [Fact]
        public async Task CreatePilot_WhenEntityIsValid_AndPlaneTypeNotExists_ThrowsHttpException()
        {
            // Arrange
            var plane = new PlaneRequest()
                            {
                                Name = "TestCreate",
                                PlaneTypeId = 1245,
                                LifeTime = new TimeSpan(11000, 0, 0),
                                CreationDate = new DateTime(1998, 12, 2)
                            };

            var planeServie = new PlaneService(_integrationFixture.Uow, _integrationFixture.ConfMapper);
            
            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => planeServie.CreateEntityAsync(plane));

            Assert.Equal($"Plane Type with Id: {plane.PlaneTypeId} doesn't exist", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }

        [Fact]
        public async Task UpdatePilot_WhenEntityIsValid_AndPlaneTypeExists_ReturnsTrue()
        {
            // Arrange
            var planeId = 4;
            var plane = new PlaneRequest()
                            {
                                Name = "TestUpdate",
                                PlaneTypeId = 2,
                                LifeTime = new TimeSpan(11000, 0, 0),
                                CreationDate = new DateTime(1998, 12, 2)
                            };

            var planeServie = new PlaneService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act
            var result = await planeServie.UpdateEntityByIdAsync(plane, planeId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task UpdatePilot_WhenEntityIsValid_AndPlaneTypeNotExists_ThrowsHttpException()
        {
            // Arrange
            var planeId = 4;
            var plane = new PlaneRequest()
                            {
                                Name = "TestCreate",
                                PlaneTypeId = 1245,
                                LifeTime = new TimeSpan(11000, 0, 0),
                                CreationDate = new DateTime(1998, 12, 2)
                            };

            var planeServie = new PlaneService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => planeServie.UpdateEntityByIdAsync(plane, planeId));

            Assert.Equal($"Plane Type with Id: {plane.PlaneTypeId} doesn't exist", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }
    }
}
