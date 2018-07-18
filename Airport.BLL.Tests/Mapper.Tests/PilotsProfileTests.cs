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
    public class PilotsProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public PilotsProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        [Fact]
        public void Pilots_Mapping_Entities()
        {
            //Arrange
            var source = DataProvider.GetPilots()[0];
            var destination = DataProvider.GetPilots()[1];

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FirstName, source.FirstName);
            Assert.Equal(destination.FamilyName, source.FamilyName);
            Assert.NotNull(destination.Crews);
            Assert.Equal(0, destination.Crews.Count);
        }

        [Fact]
        public void Pilots_Mapping_Into_Dtos()
        {
            //Arrange
            var source = DataProvider.GetPilots();

            //Act
            var destination = _servicesFixture.ConfMapper.Map<List<Pilot>, List<PilotDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
        }
    }
}
