namespace Airport.BLL.Tests.Mapper.Tests
{
    using System;
    using System.Collections.Generic;

    using AirportEf.BLL.Mapper;
    using AirportEf.DAL.Entities;

    using AutoMapper;

    using Xunit;

    public class PilotsProfileTests
    {
        [Fact]
        public void PilotMappings_ConfigurationIsValid()
        {
            //Arrange
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfile<PilotsProfile>(); });

            //Act

            //Assert
            Mapper.AssertConfigurationIsValid();
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

            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfile<PilotsProfile>(); });

            //Act
            Mapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FirstName, source.FirstName);
            Assert.Equal(destination.FamilyName, source.FamilyName);
            Assert.NotNull(destination.Crews);
        }
    }
}
