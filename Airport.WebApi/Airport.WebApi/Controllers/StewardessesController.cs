namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.BLL.Interfaces;

    public class StewardessesController : AbstractController<IStewardessService, StewardessDto, StewardessRequest, int>
    {
        public StewardessesController(IStewardessService service) : base(service)
        {
        }
    }
}
