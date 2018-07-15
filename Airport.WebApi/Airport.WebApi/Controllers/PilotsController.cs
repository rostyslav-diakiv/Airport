namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.BLL.Interfaces;
    
    public class PilotsController : AbstractController<IPilotService, PilotDto, PilotRequest, int>
    {
        public PilotsController(IPilotService service) : base(service)
        {
        }
    }
}
