namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    public class PlanesController : AbstractController<IPlaneService, PlaneDto, PlaneRequest, int>
    {
        public PlanesController(IMapper mapper, IPlaneService service)
            : base(mapper, service)
        {
        }
    }
}
