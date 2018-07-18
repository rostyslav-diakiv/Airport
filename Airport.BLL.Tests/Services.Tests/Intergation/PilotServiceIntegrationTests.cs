namespace Airport.BLL.Tests.Services.Tests.Intergation
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Requests;

    using AirportEf.BLL.Services;

    using Xunit;

    [Collection("Common Integration Collection")]
    public class PilotServiceIntegrationTests
    {
        private readonly IntegrationFixture _integrationFixture;

        public PilotServiceIntegrationTests(IntegrationFixture integrationFixture)
        {
            _integrationFixture = integrationFixture;
        }

        [Fact]
        public async Task GetAllPilots_WhenAll_5_PilotsExist()
        {
            // Arrange
            var pilotCountExpected = 5;
            var pilotServie = new PilotService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act
            var pilotsDtos = await pilotServie.GetAllEntitiesAsync();

            // Assert
            Assert.Equal(pilotCountExpected, pilotsDtos.Count());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public async Task GetPilotById_WhenPilotExists_ReturnsPilotDto(int id)
        {
            // Arrange
            var pilotServie = new PilotService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act
            var pilotDto = await pilotServie.GetEntityByIdAsync(id);

            // Assert
            Assert.Equal(id, pilotDto.Id);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(25)]
        public async Task GetPilotById_WhenPilotNotExists_ReturnsNull(int id)
        {
            // TODO: Database Integration Test
            // Arrange
            var pilotServie = new PilotService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act
            var pilotDto = await pilotServie.GetEntityByIdAsync(id);

            // Assert
            Assert.Null(pilotDto);
        }

        [Fact]
        public async Task CreatePilot_WhenEntityIsValid_ReturnsPilotDto()
        {
            // TODO: Database Integration Test
            // Arrange
            var pilot = new PilotRequest()
            {
                Name = "TestCreate",
                FamilyName = "CreateTest",
                DateOfBirth = new DateTime(1998, 12, 2),
                Experience = new TimeSpan(1000, 0, 0)
            };
            var pilotServie = new PilotService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act
            var pilotDto = await pilotServie.CreateEntityAsync(pilot);

            // Assert
            Assert.Equal(pilot.Name, pilotDto.Name);
            Assert.Equal(pilot.FamilyName, pilotDto.FamilyName);
            Assert.True(pilotDto.Id > 0);
        }
    }
}
