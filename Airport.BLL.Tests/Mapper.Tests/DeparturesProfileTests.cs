using System.Collections.Generic;

namespace Airport.BLL.Tests.Mapper.Tests
{
    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Dtos;

    using AirportEf.BLL.Mapper;
    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;

    using AutoMapper;

    using Xunit;

    public class DeparturesProfileTests : IClassFixture<DeparturesMapperFixture>
    {
        private readonly DeparturesMapperFixture _fixture;
        public DeparturesProfileTests(DeparturesMapperFixture fixture)
        {
            _fixture = fixture;
            ////Arrange
            //Mapper.Reset();
            //Mapper.Initialize(
            //    cfg =>
            //        {
            //            cfg.AddProfile<DeparturesProfile>();
            //            cfg.AddProfile<FlightsProfile>();
            //        });
        }

        [Fact]
        public void DeparturesMappings_ConfigurationIsValid()
        {


            //Act

            //Assert
            Mapper.AssertConfigurationIsValid();
        }

        [Fact]
        public void Departures_Mapping_Works()
        {
            //Arrange
            var source = DataProvider.GetDepartures()[0];
            var destination = DataProvider.GetDepartures()[0];
            destination.Id = source.Id;

            //Act
            Mapper.Map(source, destination);

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
            var destination = Mapper.Map<List<Departure>, List<DepartureDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
            Assert.NotNull(destination[1]);
            Assert.NotNull(destination[1].Flight);
        }
    }
}
