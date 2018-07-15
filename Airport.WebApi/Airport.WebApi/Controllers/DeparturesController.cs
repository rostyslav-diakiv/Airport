namespace Airport.WebApi.Controllers
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using AirportEf.BLL.Interfaces;

    public class DeparturesController : AbstractController<IDepartureService, DepartureDto, DepartureRequest, int>
    {
        public DeparturesController(IDepartureService service) : base(service)
        {
        }
    }
}
