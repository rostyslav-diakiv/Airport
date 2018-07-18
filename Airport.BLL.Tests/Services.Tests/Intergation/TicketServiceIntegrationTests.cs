namespace Airport.BLL.Tests.Services.Tests.Intergation
{
    using System.Net;
    using System.Threading.Tasks;

    using Airport.BLL.Tests.Services.Tests.TestsSetup;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Services;
    using AirportEf.DAL.Data.DataProvider;

    using Xunit;

    [Collection("Common Integration Collection")]
    public class TicketServiceIntegrationTests
    {
        private readonly IntegrationFixture _integrationFixture;

        public TicketServiceIntegrationTests(IntegrationFixture integrationFixture)
        {
            _integrationFixture = integrationFixture;
        }

        [Fact]
        public async Task CreateTicket_WhenEntityIsValid_AndFlightExists_ReturnsTicketDto()
        {
            // Arrange
            var flightId = DataProvider.GetFlights()[1].Id;
            var ticket = new TicketRequest()
            {
                Price = 1234,
                FlightNumber = flightId
            };

            var ticketService = new TicketService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act
            var ticketDto = await ticketService.CreateEntityAsync(ticket);

            // Assert
            Assert.Equal(ticket.Price, ticketDto.Price);
            Assert.Equal(ticket.FlightNumber, ticketDto.Flight.Id);
            Assert.True(ticketDto.Id > 0);
        }

        [Fact]
        public async Task CreatePilot_WhenEntityIsValid_AndPlaneTypeNotExists_ThrowsHttpException()
        {
            // Arrange
            var wrongFlightNumber = "QWERTY123";
            var ticket = new TicketRequest()
                             {
                                 Price = 1,
                                 FlightNumber = wrongFlightNumber
            };

            var ticketService = new TicketService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => ticketService.CreateEntityAsync(ticket));

            Assert.Equal($"Flight with number: {wrongFlightNumber} doesn't exist", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }

        [Fact]
        public async Task UpdatePilot_WhenEntityIsValid_AndPlaneTypeExists_ReturnsTrue()
        {
            // Arrange
            var flightId = DataProvider.GetFlights()[1].Id;
            var ticketId = 3;
            var ticket = new TicketRequest()
                             {
                                 Price = 9998,
                                 FlightNumber = flightId
                             };

            var ticketService = new TicketService(_integrationFixture.Uow, _integrationFixture.ConfMapper);
            
            // Act
            var result = await ticketService.UpdateEntityByIdAsync(ticket, ticketId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task UpdatePilot_WhenEntityIsValid_AndPlaneTypeNotExists_ThrowsHttpException()
        {
            // Arrange
            var wrongFlightNumber = "QWERTY123";
            var ticketId = 3;
            var ticket = new TicketRequest()
                             {
                                 Price = 111,
                                 FlightNumber = wrongFlightNumber
            };

            var ticketService = new TicketService(_integrationFixture.Uow, _integrationFixture.ConfMapper);

            // Act + Assert =)
            var ex = await Assert.ThrowsAsync<HttpStatusCodeException>(() => ticketService.UpdateEntityByIdAsync(ticket, ticketId));

            Assert.Equal($"Flight with number: {wrongFlightNumber} doesn't exist", ex.Message);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        }
    }
}
