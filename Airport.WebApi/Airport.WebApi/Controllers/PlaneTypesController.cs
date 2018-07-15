namespace Airport.WebApi.Controllers
{
    using AirportEf.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public class PlaneTypesController : AbstractController<IPlaneTypeService, PlaneTypeDto, PlaneTypeRequest, int>
    {
        public PlaneTypesController(IPlaneTypeService service) : base(service)
        {
        }
    }
}
