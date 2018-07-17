namespace Airport.BLL.Tests.Services.Tests.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using AirportEf.BLL.Mapper;
    using AirportEf.BLL.Services;
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
        public async Task GetPilotById_2_WhenPilotExists()
        {
            // Arrange Mock
            var uowMock = new Mock<IUnitOfWork>();
            var pilotRepoMock = new Mock<IPilotRepository>();
            var a = It.IsAny<int>();
            pilotRepoMock.Setup(repo => repo.GetRangeAsync(a, 
                                                           It.IsAny<int>(), 
                                                           It.IsAny<Expression<Func<Pilot, bool>>>(), 
                                                           It.IsAny<Func<IQueryable<Pilot>, IOrderedQueryable<Pilot>>>(),
                                                           It.IsAny<Func<IQueryable<Pilot>, IIncludableQueryable<Pilot, object>>>(),
                                                           It.IsAny<bool>()))
                            .Returns(Task.FromResult(GetTestPilots()));

            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            // Arrange Real for testing
            var pilotsProfile = new PilotsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(pilotsProfile));
            var mapper = new Mapper(configuration);

            var pilotServie = new PilotService(uowMock.Object, mapper);

            // Act
            var pilotDto = await pilotServie.GetAllEntitiesAsync();

            // Assert
            // var createdResult = actionResult as CreatedResult;
            //Assert.Equal(201, createdResult.StatusCode);

            Assert.Equal(2, pilotDto.Count());
        }

        // Mock Data
        private List<Pilot> GetTestPilots()
        {
            var pilots = new List<Pilot>
                             {
                                 new Pilot()
                                     {
                                         Id = 1,
                                         FirstName = "Qwerty",
                                         FamilyName = "Qwerty",
                                         DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                                         Experience = new TimeSpan(1600, 00, 00, 00),
                                     },
                                 new Pilot()
                                     {
                                         Id = 2,
                                         FirstName = "Ostap",
                                         FamilyName = "Bober",
                                         DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                                         Experience = new TimeSpan(3600, 00, 00, 00),
                                     }
                             };
            return pilots;
        }
    }
}
