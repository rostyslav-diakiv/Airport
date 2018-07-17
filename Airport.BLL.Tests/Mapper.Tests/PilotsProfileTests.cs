namespace Airport.BLL.Tests.Mapper.Tests
{
    using System;
    using System.Collections.Generic;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;

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
        public void PilotMappings_ConfigurationIsValids()
        {
            //Arrange
            Pilot source = new Pilot()
            {
                Id = 1,
                FirstName = "Arara",
                FamilyName = "Qwerty",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(800, 00, 00, 00),
                Crews = null
            };
            Pilot destination = new Pilot()
            {
                Id = 1,
                FirstName = "Serg",
                FamilyName = "Karas",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(800, 00, 00, 00),
                Crews = new List<Crew>()
            };

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FirstName, source.FirstName);
            Assert.Equal(destination.FamilyName, source.FamilyName);
            Assert.NotNull(destination.Crews);
        }
    }
}
