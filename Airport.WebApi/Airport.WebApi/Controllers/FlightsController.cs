namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;
    using AutoMapper;

    public class FlightsController : AbstractController<IFlightService, FlightDto, FlightRequest, string>
    {
        public FlightsController(IMapper mapper, IFlightService service)
            : base(mapper, service)
        {
        }
    }
}
