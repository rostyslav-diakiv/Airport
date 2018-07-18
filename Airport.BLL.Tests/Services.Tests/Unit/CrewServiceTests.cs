namespace Airport.BLL.Tests.Services.Tests.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Services;
    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;
    using AirportEf.DAL.Interfaces.Repositories;

    using Microsoft.EntityFrameworkCore.Query;

    using Moq;

    using Xunit;

    [Collection("Common Services Collection")]
    public class CrewServiceTests
    {
        private readonly ServicesFixture _servicesFixture;
        public CrewServiceTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        #region Create Tests

        [Fact]
        public async Task GetAllCrews_ReturnsListCrewDto()
        {
            // Arrange Mock
            var uowMock = new Mock<IUnitOfWork>();
            var crewRepoMock = new Mock<ICrewRepository>();
            var crewsMock = DataProvider.GetCrews();
            var setup = crewRepoMock.Setup(
                repo => repo.GetRangeAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Crew, bool>>>(),
                    It.IsAny<Func<IQueryable<Crew>, IOrderedQueryable<Crew>>>(),
                    It.IsAny<Func<IQueryable<Crew>, IIncludableQueryable<Crew, object>>>(),
                    It.IsAny<bool>()));

            setup.Returns(Task.FromResult(crewsMock));
            // .Returns(Task.FromResult(crewsMock));

            uowMock.Setup(work => work.CrewRepository).Returns(crewRepoMock.Object);

            var crewServie = new CrewService(uowMock.Object, _servicesFixture.ConfMapper);

            // Act
            var crewDtos = await crewServie.GetAllEntitiesAsync();

            // Assert
            Assert.Equal(5, crewDtos.Count());
        }

        [Fact]
        public async Task CreateCrew_WithExistingPilotAndNotExistingStewardesses_ThrowsHttpException()
        {
            // Arrange Mocks
            var stewardessListMock = DataProvider.GetStewardesses().GetRange(0, 1);
            var uowMock = new Mock<IUnitOfWork>();
            var crewRepoMock = new Mock<ICrewRepository>();

            var stewRepoMock = new Mock<IStewardessRepository>();
            stewRepoMock.Setup(repo => repo.GetRangeAsync(It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Stewardess, bool>>>(),
                    It.IsAny<Func<IQueryable<Stewardess>, IOrderedQueryable<Stewardess>>>(),
                    It.IsAny<Func<IQueryable<Stewardess>, IIncludableQueryable<Stewardess, object>>>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult(stewardessListMock));

            uowMock.Setup(work => work.CrewRepository).Returns(crewRepoMock.Object);
            uowMock.Setup(work => work.StewardessRepository).Returns(stewRepoMock.Object);

            var crewServie = new CrewService(uowMock.Object, _servicesFixture.ConfMapper);
            var crewRequest = new CrewRequest() { PilotId = 2, StewardessesIds = new List<int> { 1, 3, 4, 2 } };


            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => crewServie.CreateEntityAsync(crewRequest));

            Assert.Equal("One or more Stewardesses with such ids not found", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }

        [Fact]
        public async Task CreateCrew_WithNotExistingPilotAndExistingStewardesses_ThrowsHttpException()
        {
            // Arrange Mocks
            var stewardessListMock = DataProvider.GetStewardesses().GetRange(0, 1);
            var uowMock = new Mock<IUnitOfWork>();
            var crewRepoMock = new Mock<ICrewRepository>();

            var stewRepoMock = new Mock<IStewardessRepository>();
            stewRepoMock.Setup(repo => repo.GetRangeAsync(It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Stewardess, bool>>>(),
                    It.IsAny<Func<IQueryable<Stewardess>, IOrderedQueryable<Stewardess>>>(),
                    It.IsAny<Func<IQueryable<Stewardess>, IIncludableQueryable<Stewardess, object>>>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult(stewardessListMock));

            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.GetFirstOrDefaultAsync(
                    It.IsAny<Expression<Func<Pilot, bool>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IOrderedQueryable<Pilot>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IIncludableQueryable<Pilot, object>>>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult<Pilot>(null));

            uowMock.Setup(work => work.CrewRepository).Returns(crewRepoMock.Object);
            uowMock.Setup(work => work.StewardessRepository).Returns(stewRepoMock.Object);
            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            var pilotIdMock = 2;
            var crewServie = new CrewService(uowMock.Object, _servicesFixture.ConfMapper);
            var crewRequest = new CrewRequest() { PilotId = pilotIdMock, StewardessesIds = new List<int> { 1 } };


            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => crewServie.CreateEntityAsync(crewRequest));

            Assert.Equal($"Pilot with id: {pilotIdMock} not found", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }

        // Successful Create
        [Fact]
        public async Task CreateCrew_WithExistingPilotAndExistingStewardesses_ReturnsCreatedCrewDto()
        {
            // Arrange Mocks
            var stewardessListMock = DataProvider.GetStewardesses().GetRange(0, 2);
            var pilotMock = DataProvider.GetPilots()[0]; // Id = 1
            var crewMock = DataProvider.GetCrews()[0];

            var crewRepoMock = new Mock<ICrewRepository>();
            crewRepoMock.Setup(repo => repo.CreateAsync(It.IsAny<Crew>()))
                .Returns(Task.FromResult(crewMock));

            var stewRepoMock = new Mock<IStewardessRepository>();
            stewRepoMock.Setup(repo => repo.GetRangeAsync(It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Stewardess, bool>>>(),
                    It.IsAny<Func<IQueryable<Stewardess>, IOrderedQueryable<Stewardess>>>(),
                    It.IsAny<Func<IQueryable<Stewardess>, IIncludableQueryable<Stewardess, object>>>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult(stewardessListMock));

            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.GetFirstOrDefaultAsync(
                    It.IsAny<Expression<Func<Pilot, bool>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IOrderedQueryable<Pilot>>>(),
                    It.IsAny<Func<IQueryable<Pilot>, IIncludableQueryable<Pilot, object>>>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult<Pilot>(pilotMock));

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(repo => repo.SaveAsync()).Returns(Task.FromResult(true));
            uowMock.Setup(work => work.CrewRepository).Returns(crewRepoMock.Object);
            uowMock.Setup(work => work.StewardessRepository).Returns(stewRepoMock.Object);
            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            var crewServie = new CrewService(uowMock.Object, _servicesFixture.ConfMapper);
            var crewRequest = new CrewRequest() { PilotId = pilotMock.Id, StewardessesIds = new List<int> { 1, 2 } };

            // Act
            var crewDto = await crewServie.CreateEntityAsync(crewRequest);

            // Assert 
            Assert.Equal(pilotMock.Id, crewDto.Pilot.Id);
            Assert.Equal(stewardessListMock.Count, crewDto.Stewardesses.Count());
        }
        #endregion

        #region Update tests

        // Successful Update
        [Fact]
        public async Task UpdateCrew_WithExistingPilotAndExistingStewardesses_ReturnsTrue()
        {
            // Arrange Mocks
            var crewId = 3;
            var crewMock = DataProvider.GetCrews()[0];

            var crewRepoMock = new Mock<ICrewRepository>();
            crewRepoMock.Setup(repo => repo.CreateAsync(It.IsAny<Crew>()))
                .Returns(Task.FromResult(crewMock));

            var stewRepoMock = new Mock<IStewardessRepository>();
            stewRepoMock.Setup(repo => repo.CountAsync(It.IsAny<Expression<Func<Stewardess, bool>>>()))
                .Returns(Task.FromResult(2));

            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.ExistAsync(It.IsAny<Expression<Func<Pilot, bool>>>()))
                .Returns(Task.FromResult(true));

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(repo => repo.SaveAsync()).Returns(Task.FromResult(true));
            uowMock.Setup(work => work.CrewRepository).Returns(crewRepoMock.Object);
            uowMock.Setup(work => work.StewardessRepository).Returns(stewRepoMock.Object);
            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            var crewServie = new CrewService(uowMock.Object, _servicesFixture.ConfMapper);
            var crewRequest = new CrewRequest() { PilotId = 2, StewardessesIds = new List<int> { 1, 2 } };

            // Act
            var result = await crewServie.UpdateEntityByIdAsync(crewRequest, crewId);

            // Assert 
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateCrew_WithExistingPilotAndNotExistingStewardesses_ThrowsHttpException()
        {
            // Arrange Mocks
            var crewId = 3;
            var crewMock = DataProvider.GetCrews()[0];

            var crewRepoMock = new Mock<ICrewRepository>();
            crewRepoMock.Setup(repo => repo.CreateAsync(It.IsAny<Crew>()))
                .Returns(Task.FromResult(crewMock));

            var stewRepoMock = new Mock<IStewardessRepository>();
            stewRepoMock.Setup(repo => repo.CountAsync(It.IsAny<Expression<Func<Stewardess, bool>>>()))
                .Returns(Task.FromResult(1));

            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.ExistAsync(It.IsAny<Expression<Func<Pilot, bool>>>()))
                .Returns(Task.FromResult(true));

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(work => work.CrewRepository).Returns(crewRepoMock.Object);
            uowMock.Setup(work => work.StewardessRepository).Returns(stewRepoMock.Object);
            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            var crewServie = new CrewService(uowMock.Object, _servicesFixture.ConfMapper);
            var crewRequest = new CrewRequest() { PilotId = 2, StewardessesIds = new List<int> { 1, 2 } };

            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => crewServie.UpdateEntityByIdAsync(crewRequest, crewId));

            Assert.Equal("One or more Stewardesses with such ids not found", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }

        [Fact]
        public async Task UpdateCrew_WithNotExistingPilotAndExistingStewardesses_ThrowsHttpException()
        {
            // Arrange Mocks
            var crewId = 3;
            var pilotId = 1245;
            var crewMock = DataProvider.GetCrews()[0];

            var crewRepoMock = new Mock<ICrewRepository>();
            crewRepoMock.Setup(repo => repo.CreateAsync(It.IsAny<Crew>()))
                .Returns(Task.FromResult(crewMock));

            var stewRepoMock = new Mock<IStewardessRepository>();
            stewRepoMock.Setup(repo => repo.CountAsync(It.IsAny<Expression<Func<Stewardess, bool>>>()))
                .Returns(Task.FromResult(2));

            var pilotRepoMock = new Mock<IPilotRepository>();
            pilotRepoMock.Setup(repo => repo.ExistAsync(It.IsAny<Expression<Func<Pilot, bool>>>()))
                .Returns(Task.FromResult(false));

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(work => work.CrewRepository).Returns(crewRepoMock.Object);
            uowMock.Setup(work => work.StewardessRepository).Returns(stewRepoMock.Object);
            uowMock.Setup(work => work.PilotRepository).Returns(pilotRepoMock.Object);

            var crewServie = new CrewService(uowMock.Object, _servicesFixture.ConfMapper);
            var crewRequest = new CrewRequest() { PilotId = pilotId, StewardessesIds = new List<int> { 1, 2 } };

            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => crewServie.UpdateEntityByIdAsync(crewRequest, crewId));

            Assert.Equal($"Pilot with id: {pilotId} not found", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }

        #endregion
    }
}
