namespace Airport.WebApi.Controllers
{
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : AbstractController<IFlightService, FlightDto, FlightRequest, string>
    {
        public FlightsController(IMapper mapper, IFlightService service)
            : base(mapper, service)
        {
        }

        public override Task<ActionResult<FlightDto>> Update(string id, FlightRequest request)
        {
            // TODO: Remove name from Update Flight model
            return base.Update(id, request);
        }
    }
}
