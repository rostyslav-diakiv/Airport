namespace Airport.BLL.Tests.Mapper.Tests
{
    using System;
    using System.Collections.Generic;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Dtos;

    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;

    using Xunit;

    [Collection("Common Services Collection")]
    public class PlanesProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public PlanesProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        [Fact]
        public void Planes_Mapping_Entities()
        {
            //Arrange
            var source = DataProvider.GetPlanes()[0];
            var destination = DataProvider.GetPlanes()[1];
            destination.Id = source.Id;

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.CreationDate, source.CreationDate);
            Assert.Equal(destination.Name, source.Name);
            Assert.Equal(0, destination.Departures.Count);
        }

        [Fact]
        public void Planes_Mapping_Map_Into_Dtos()
        {
            //Arrange
            var source = DataProvider.GetPlanes();

            //Act
            var destination = _servicesFixture.ConfMapper.Map<List<Plane>, List<PlaneDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
            Assert.NotNull(destination[1]);
            Assert.NotNull(destination[1].PlaneType);
        }
    }
}
