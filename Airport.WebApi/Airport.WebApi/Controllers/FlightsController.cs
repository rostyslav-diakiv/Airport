namespace Airport.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : AbstractController<IFlightService, FlightDto, FlightRequest, string>
    {
        public FlightsController(IFlightService service) : base(service)
        {
        }

        // GET: api/Flights/Delayed
        [HttpGet("Delayed")]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetDelayed()
        {
            var dtos = await service.GetAllEntitiesDelayedAsync(5000);
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }
    }
}
