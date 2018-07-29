namespace ClientLight.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClientLight.Model;

    public interface ITicketsService
    {
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();

        Task<TicketDto> CreateTicketAsync(TicketDto ticketDto);

        Task<bool> UpdateTicketByIdAsync(TicketDto ticketDto);

        Task<bool> DeleteTicketByIdAsync(int id);
    }
}