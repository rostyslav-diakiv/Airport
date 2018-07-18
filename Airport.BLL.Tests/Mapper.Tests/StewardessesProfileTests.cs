namespace Airport.BLL.Tests.Mapper.Tests
{
    using System.Collections.Generic;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Dtos;

    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;

    using Xunit;

    [Collection("Common Services Collection")]
    public class StewardessesProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public StewardessesProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        [Fact]
        public void Stewardesses_Mapping_Entities()
        {
            //Arrange
            Stewardess source = DataProvider.GetStewardesses()[0];
            Stewardess destination = DataProvider.GetStewardesses()[1];
            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FirstName, source.FirstName);
            Assert.Equal(destination.FamilyName, source.FamilyName);
            Assert.NotNull(destination.CrewStewardess);
        }

        [Fact]
        public void Stewardesses_Mapping_Map_Into_Dtos()
        {
            //Arrange
            var source = DataProvider.GetStewardesses();

            //Act
            var destination = _servicesFixture.ConfMapper.Map<List<Stewardess>, List<StewardessDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
        }
    }
}
