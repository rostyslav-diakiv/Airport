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
            //using (var client = new HttpClient(FilterProvider.GetFilter()))
            //{
            //    var msg = await client.GetAsync(new Uri("http://localhost:10297/api/Tickets"));

            //    if (!msg.IsSuccessStatusCode) return null;

            //    var pilotDtos = await msg.Content.ReadAsJsonAsync<List<TicketDto>>();

            //    return pilotDtos;
            //}
        }

        public Task<TicketDto> CreateEntityAsync(TicketDto ticketDto)
        {
            var request = new TicketRequest
                              {
                                  Price = ticketDto.Price,
                                  FlightNumber = ticketDto.Flight.Number
                              };

            return base.CreateEntitiesAsync(request, Ctrl_Name);
            //using (var client = new HttpClient(FilterProvider.GetFilter()))
            //{
            //    var response = await client.PostAsJsonAsync(new Uri("http://localhost:10297/api/Tickets"), request);

            //    if (!response.IsSuccessStatusCode) return null;

            //    var dto = await response.Content.ReadAsJsonAsync<TicketDto>();

            //    return dto;
            //}
        }

        public Task<bool> UpdateEntityByIdAsync(TicketDto ticketDto)
        {
            var request = new TicketRequest
                              {
                                  Price = ticketDto.Price,
                                  FlightNumber = ticketDto.Flight.Number
                              };

            return base.UpdateEntitiesByIdAsync(request, ticketDto.Id, Ctrl_Name);

            //using (var client = new HttpClient(FilterProvider.GetFilter()))
            //{
            //    var response = await client.PutAsJsonAsync(new Uri($"http://localhost:10297/api/Tickets/{ticketDto.Id}"), request);

            //    return response.IsSuccessStatusCode;
            //}
        }

        public Task<bool> DeleteEntityByIdAsync(int id)
        {
            return base.DeleteEntitiesByIdAsync(id, Ctrl_Name);
            //using (var client = new HttpClient(FilterProvider.GetFilter()))
            //{
            //    var response = await client.DeleteAsync(new Uri($"http://localhost:10297/api/Tickets/{id}"));

            //    return response.IsSuccessStatusCode;
            //}
        }
    }
}
