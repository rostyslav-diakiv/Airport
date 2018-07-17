namespace Airport.BLL.Tests.Services.Tests.Intergation
{
    using System.Linq;
    using System.Threading.Tasks;

    using AirportEf.BLL.Mapper;
    using AirportEf.BLL.Services;
    using AirportEf.BLL.Utils;
    using AirportEf.DAL;
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    public class PilotServiceIntegrationTests
    {
        [Fact]
        public async Task GetAllPilots_WhenAll_5_PilotsExist()
        {
            // TODO: Database Integration Test
            // Arrange
            var options = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase(databaseName: "GetTest")
                .Options;
            AirportDbContext context = new AirportDbContext(options);
            DatabaseSeeder.SeedAction(context);

            var pilotsProfile = new PilotsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pilotsProfile));
            var mapper = new Mapper(configuration);

            IUnitOfWork uow = new UnitOfWork(context, mapper);

            var pilotServie = new PilotService(uow, mapper);

            // Act
            var pilotsDtos = await pilotServie.GetAllEntitiesAsync();

            Assert.Equal(5, pilotsDtos.Count());
        }

        [Fact]
        public async Task GetPilotById_WhenPilotExists()
        {
            // TODO: Database Integration Test
            // Arrange
            var options = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase(databaseName: "GetTest")
                .Options;
            AirportDbContext context = new AirportDbContext(options);
            DatabaseSeeder.SeedAction(context);

            var pilotsProfile = new PilotsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pilotsProfile));
            var mapper = new Mapper(configuration);

            IUnitOfWork uow = new UnitOfWork(context, mapper);

            var pilotServie = new PilotService(uow, mapper);

            // Act
            var pilotDto = await pilotServie.GetEntityByIdAsync(2);

            // Assert
            Assert.Equal(2, pilotDto.Id);
        }
    }
}
