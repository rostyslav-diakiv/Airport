namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    public class DeparturesController : AbstractController<IDepartureService, DepartureDto, DepartureRequest, int>
    {
        public DeparturesController(IMapper mapper, IDepartureService service)
            : base(mapper, service)
        {
        }
    }
}
