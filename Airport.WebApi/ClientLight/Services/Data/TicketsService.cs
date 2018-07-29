namespace ClientLight.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Windows.Web.Http;

    using ClientLight.Extensions;
    using ClientLight.Helpers;
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Requests;

    public class TicketsService : ITicketsService
    {
        public TicketsService()
        {
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync()
        {
            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var msg = await client.GetAsync(new Uri("http://localhost:10297/api/Tickets"));
                
                if (!msg.IsSuccessStatusCode) return null;

                var pilotDtos = await msg.Content.ReadAsJsonAsync<List<TicketDto>>();

                return pilotDtos;
            }
        }

        public async Task<TicketDto> CreateTicketAsync(TicketDto ticketDto)
        {
            var request = new TicketRequest
                              {
                                  Price = ticketDto.Price,
                                  FlightNumber = ticketDto.Flight.Number
                              };

            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var response = await client.PostAsJsonAsync(new Uri("http://localhost:10297/api/Tickets"), request);

                if (!response.IsSuccessStatusCode) return null;

                var dto = await response.Content.ReadAsJsonAsync<TicketDto>();

                return dto;
            }
        }

        public async Task<bool> UpdateTicketByIdAsync(TicketDto ticketDto)
        {
            var request = new TicketRequest
                              {
                                  Price = ticketDto.Price,
                                  FlightNumber = ticketDto.Flight.Number
                              };

            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var response = await client.PutAsJsonAsync(new Uri($"http://localhost:10297/api/Tickets/{ticketDto.Id}"), request);

                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteTicketByIdAsync(int id)
        {
            using (var client = new HttpClient(FilterProvider.GetFilter()))
            {
                var response = await client.DeleteAsync(new Uri($"http://localhost:10297/api/Tickets/{id}"));

                return response.IsSuccessStatusCode;
            }
        }
    }
}
