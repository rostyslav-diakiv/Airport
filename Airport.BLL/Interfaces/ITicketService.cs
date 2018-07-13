namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;

    public interface ITicketService : IService<Ticket, TicketDto, TicketRequest, int>
    {
    }
}