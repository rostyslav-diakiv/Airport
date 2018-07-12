namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;
    
    public class PilotsController : AbstractController<IPilotService, PilotDto, PilotRequest, int>
    {
        public PilotsController(IMapper mapper, IPilotService service)
            : base(mapper, service)
        {
        }
    }
}
