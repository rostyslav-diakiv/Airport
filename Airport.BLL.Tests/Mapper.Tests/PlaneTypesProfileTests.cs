namespace Airport.BLL.Tests.Mapper.Tests
{
    using System.Collections.Generic;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Dtos;

    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;

    using Xunit;

    [Collection("Common Services Collection")]
    public class PlaneTypesProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public PlaneTypesProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        [Fact]
        public void PlaneTypes_Mapping_Entities()
        {
            //Arrange
            var source = DataProvider.GetPlaneTypes()[0];
            var destination = DataProvider.GetPlaneTypes()[1];
            destination.Id = source.Id;

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.MaxCarryingCapacityKg, source.MaxCarryingCapacityKg);
            Assert.Equal(destination.PlaneModel, source.PlaneModel);
            Assert.Equal(0, destination.Planes.Count);
        }

        [Fact]
        public void PlaneTypes_Mapping_Map_Into_Dtos()
        {
            //Arrange
            var source = DataProvider.GetPlaneTypes();

            //Act
            var destination = _servicesFixture.ConfMapper.Map<List<PlaneType>, List<PlaneTypeDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
        }
    }
}
