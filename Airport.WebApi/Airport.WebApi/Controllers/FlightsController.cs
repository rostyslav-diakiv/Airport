﻿namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;

    public class FlightsController : AbstractController<IFlightService, FlightDto, FlightRequest, string>
    {
        public FlightsController(IFlightService service) : base(service)
        {
        }
    }
}
