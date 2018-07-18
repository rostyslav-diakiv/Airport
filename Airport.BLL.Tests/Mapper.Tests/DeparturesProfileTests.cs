using System.Collections.Generic;

namespace Airport.BLL.Tests.Mapper.Tests
{
    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Dtos;

    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;

    using Xunit;

    [Collection("Common Services Collection")]
    public class DeparturesProfileTests
    {
        private readonly ServicesFixture _servicesFixture;
        public DeparturesProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        [Fact]
        public void Departures_Mapping_Entities()
        {
            //Arrange
            var source = DataProvider.GetDepartures()[0];
            var destination = DataProvider.GetDepartures()[0];
            destination.Id = source.Id;

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FlightId, source.FlightId);
            Assert.Equal(destination.CrewId, source.CrewId);
            Assert.NotNull(destination.Crew);
            Assert.NotNull(destination.Plane);
            Assert.NotNull(destination.Flight);
        }

        [Fact]
        public void Departures_Mapping_Map_Into_Dtos()
        {
            //Arrange
            var source = DataProvider.GetDepartures();

            //Act
            var destination = _servicesFixture.ConfMapper.Map<List<Departure>, List<DepartureDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
            Assert.NotNull(destination[1]);
            Assert.NotNull(destination[1].Flight);
        }
    }
}
