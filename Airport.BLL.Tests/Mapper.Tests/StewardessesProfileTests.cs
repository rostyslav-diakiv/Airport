namespace Airport.BLL.Tests.Mapper.Tests
{
    using System;
    using System.Collections.Generic;

    using AirportEf.BLL.Mapper;
    using AirportEf.DAL.Entities;
    using AutoMapper;
    using Xunit;

    public class StewardessesProfileTests
    {
        [Fact]
        public void PilotMappings_ConfigurationIsValid()
        {
            //Arrange
            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfile<StewardessProfile>(); });

            //Act

            //Assert
            Mapper.AssertConfigurationIsValid();
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

            Mapper.Reset();
            Mapper.Initialize(cfg => { cfg.AddProfile<StewardessProfile>(); }); // TODO: Зробити ClassFixture щоб кожен раз не повторяти ініціалізцію маппера

            //Act
            Mapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FirstName, source.FirstName);
            Assert.Equal(destination.FamilyName, source.FamilyName);
            Assert.NotNull(destination.CrewStewardess);
        }
    }
}
