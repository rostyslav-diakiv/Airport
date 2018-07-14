namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;
    using AutoMapper;

    public class TicketsController : AbstractController<ITicketService, TicketDto, TicketRequest, int>
    {
        public TicketsController(IMapper mapper, ITicketService service)
            : base(mapper, service)
        {
        }
    }
}
