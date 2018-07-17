namespace Airport.BLL.Tests.Mapper.Tests
{
    using System;
    using System.Collections.Generic;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;

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
        public void PilotMappings_ConfigurationIsValids()
        {
            //Arrange
            Stewardess source = new Stewardess()
                               {
                                   Id = 1,
                                   FirstName = "Arara",
                                   FamilyName = "Qwerty",
                                   DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                                   CrewStewardess = null
                               };
            Stewardess destination = new Stewardess()
                                    {
                                        Id = 1,
                                        FirstName = "Serg",
                                        FamilyName = "Karas",
                                        DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                                        CrewStewardess = new List<CrewStewardess>()
                                    };

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FirstName, source.FirstName);
            Assert.Equal(destination.FamilyName, source.FamilyName);
            Assert.NotNull(destination.CrewStewardess);
        }
    }
}
