namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    public class CrewsController : AbstractController<ICrewService, CrewDto, CrewRequest, int>
    {
        public CrewsController(IMapper mapper, ICrewService service) : base(mapper, service)
        {
        }
    }
}
