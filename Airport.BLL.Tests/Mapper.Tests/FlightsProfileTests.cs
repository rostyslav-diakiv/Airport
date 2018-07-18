namespace Airport.BLL.Tests.Mapper.Tests
{
    using System.Collections.Generic;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Dtos;

    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;

    using Xunit;

    [Collection("Common Services Collection")]
    public class FlightsProfileTests
    {
        private readonly ServicesFixture _servicesFixture;
        public FlightsProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        [Fact]
        public void Flights_Mapping_Entities()
        {
            //Arrange
            var source = DataProvider.GetFlights()[0];
            var destination = DataProvider.GetFlights()[1];
            destination.Id = source.Id;

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.Id, source.Id);
            Assert.Equal(destination.DeparturePoint, source.DeparturePoint);
        }

        [Fact]
        public void Flights_Mapping_Map_Into_Dtos()
        {
            //Arrange
            var source = DataProvider.GetFlights();

            //Act
            var destination = _servicesFixture.ConfMapper.Map<List<Flight>, List<FlightDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
            Assert.NotNull(destination[1]);
        }
    }
}
