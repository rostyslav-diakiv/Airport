namespace Airport.BLL.Tests.Services.Tests.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using AirportEf.BLL.Mapper;
    using AirportEf.BLL.Services;
    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore.Query;

    using Moq;

    using Xunit;

    public class PilotServiceTests
    {
        [Fact]
        public async Task GetAllPilots_WhenAll_5_PilotsExist()
        {
            // Arrange Mock
            var uowMock = new Mock<IUnitOfWork>();
            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.GetRangeAsync(It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Pilot, bool>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IOrderedQueryable<Pilot>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IIncludableQueryable<Pilot, object>>>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult(DataProvider.GetPilots()));

            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            // Arrange Real for testing
            var pilotsProfile = new PilotsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pilotsProfile));
            var mapper = new Mapper(configuration);

            var pilotServie = new PilotService(uowMock.Object, mapper);

            // Act
            var pilotDto = await pilotServie.GetAllEntitiesAsync();

            // Assert
            Assert.Equal(5, pilotDto.Count());
        }

        [Fact]
        public async Task GetPilotById_2_WhenPilotExists()
        {
            // Arrange Mock
            var pilotId = 2;
            var pilot = DataProvider.GetPilots()[1];
            var uowMock = new Mock<IUnitOfWork>();
            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Pilot, bool>>>(), 
                                                           It.IsAny<Func<IQueryable<Pilot>, IOrderedQueryable<Pilot>>>(),
                                                           It.IsAny<Func<IQueryable<Pilot>, IIncludableQueryable<Pilot, object>>>(),
                                                           It.IsAny<bool>()))
                            .Returns(Task.FromResult(pilot));

            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            // Arrange Real for testing
            var pilotsProfile = new PilotsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pilotsProfile));
            var mapper = new Mapper(configuration);

            var pilotServie = new PilotService(uowMock.Object, mapper);

            // Act
            var pilotDto = await pilotServie.GetEntityByIdAsync(pilotId);

            // Assert
            Assert.Equal(2, pilotDto.Id);
        }

        [Fact]
        public async Task GetPilotById_44_WhenPilotNotExists()
        {
            // Arrange Mock
            var pilotId = 42;
            var pilot = DataProvider.GetPilots()[1];
            var uowMock = new Mock<IUnitOfWork>();
            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Pilot, bool>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IOrderedQueryable<Pilot>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IIncludableQueryable<Pilot, object>>>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult(pilot));

            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            // Arrange Real for testing
            var pilotsProfile = new PilotsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pilotsProfile));
            var mapper = new Mapper(configuration);

            var pilotServie = new PilotService(uowMock.Object, mapper);

            // Act
            var pilotDto = await pilotServie.GetEntityByIdAsync(pilotId);

            // Assert
            Assert.Equal(2, pilotDto.Id);
        }
    }
}
