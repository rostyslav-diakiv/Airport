namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;
    using AutoMapper;

    public class DeparturesController : AbstractController<IDepartureService, DepartureDto, DepartureRequest, int>
    {
        public DeparturesController(IMapper mapper, IDepartureService service)
            : base(mapper, service)
        {
        }
    }
}
