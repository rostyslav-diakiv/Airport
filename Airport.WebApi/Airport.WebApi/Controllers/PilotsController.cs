using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.BLL.Interfaces;

    using AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class PilotsController : AbstractController<IPilotService, PilotDto, PilotRequest, int>
    {
        public PilotsController(IMapper mapper, IPilotService service)
            : base(mapper, service)
        {
        }
    }
}
