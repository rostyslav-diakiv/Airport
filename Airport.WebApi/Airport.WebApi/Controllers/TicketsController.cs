namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;

    public class TicketsController : AbstractController<ITicketService, TicketDto, TicketRequest, int>
    {
        public TicketsController(ITicketService service) : base(service)
        {
        }
    }
}
