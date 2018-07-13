namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    public class PlaneTypesController : AbstractController<IPlaneTypeService, PlaneTypeDto, PlaneTypeRequest, int>
    {
        public PlaneTypesController(IMapper mapper, IPlaneTypeService service)
            : base(mapper, service)
        {
        }
    }
}
