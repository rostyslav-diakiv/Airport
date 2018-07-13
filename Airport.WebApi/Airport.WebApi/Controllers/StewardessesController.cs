namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    public class StewardessesController : AbstractController<IStewardessService, StewardessDto, StewardessRequest, int>
    {
        public StewardessesController(IMapper mapper, IStewardessService service) : base(mapper, service)
        {
        }
    }
}
