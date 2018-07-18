namespace Airport.BLL.Tests.Mapper.Tests
{
    using System;

    using AirportEf.BLL.Mapper;

    using AutoMapper;

    using Xunit;

    public class MapperConfigurationTests
    {
        [Fact]
        public void TestConfig()
        {
            //Arrange
            Mapper.Reset();
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.AddProfile<CrewsProfile>();
                        cfg.AddProfile<DeparturesProfile>();
                        cfg.AddProfile<FlightsProfile>();
                        cfg.AddProfile<PilotsProfile>();
                        cfg.AddProfile<PlanesProfile>();
                        cfg.AddProfile<PlaneTypesProfile>();
                        cfg.AddProfile<StewardessProfile>();
                        cfg.AddProfile<TicketsProfile>();
                    });

            //Act

            //Assert
            Mapper.AssertConfigurationIsValid(); 
        }
    }
}

