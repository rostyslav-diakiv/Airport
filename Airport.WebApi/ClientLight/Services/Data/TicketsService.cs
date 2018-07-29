namespace ClientLight.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;

    public class TicketsService : BaseService<TicketDto, TicketRequest, int>, ITicketsService
    {
        public const string Ctrl_Name = "Tickets";
        public TicketsService()
        {
        }

        public Task<IEnumerable<TicketDto>> GetAllEntitiesAsync()
        {
            return base.GetAllEntities(Ctrl_Name);
        }

        public Task<TicketDto> CreateEntityAsync(TicketDto ticketDto)
        {
            var request = new TicketRequest
                              {
                                  Price = ticketDto.Price,
                                  FlightNumber = ticketDto.Flight.Number
                              };

            return base.CreateEntitiesAsync(request, Ctrl_Name);
        }

        public Task<bool> UpdateEntityByIdAsync(TicketDto ticketDto)
        {
            var request = new TicketRequest
                              {
                                  Price = ticketDto.Price,
                                  FlightNumber = ticketDto.Flight.Number
                              };

            return base.UpdateEntitiesByIdAsync(request, ticketDto.Id, Ctrl_Name);
        }

        public Task<bool> DeleteEntityByIdAsync(int id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
        }
    }
}
