namespace Airport.BLL.Tests.Mapper.Tests
{
    using System.Collections.Generic;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Dtos;

    using AirportEf.DAL.Data.DataProvider;
    using AirportEf.DAL.Entities;

    using Xunit;

    [Collection("Common Services Collection")]
    public class TicketsProfileTests
    {
        private readonly ServicesFixture _servicesFixture;

        public TicketsProfileTests(ServicesFixture servicesFixture)
        {
            _servicesFixture = servicesFixture;
        }

        [Fact]
        public void Tickets_Mapping_Entities()
        {
            //Arrange
            var source = DataProvider.GetTickets()[0];
            var destination = DataProvider.GetTickets()[1];
            destination.Id = source.Id;

            //Act
            _servicesFixture.ConfMapper.Map(source, destination);

            //Assert
            Assert.Equal(destination.FlightId, source.FlightId);
            Assert.Equal(destination.Price, source.Price);
            Assert.NotNull(destination.Flight);
        }

        [Fact]
        public void Tickets_Mapping_Map_Into_Dtos()
        {
            //Arrange
            var source = DataProvider.GetTickets();

            //Act
            var destination = _servicesFixture.ConfMapper.Map<List<Ticket>, List<TicketDto>>(source);

            //Assert
            Assert.Equal(source.Count, destination.Count);
        }
    }
}
