namespace Airport.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface ITicketService : IService<TicketDto, TicketRequest, int>
    {
    }
}