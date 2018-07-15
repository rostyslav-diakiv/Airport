namespace Airport.WebApi.Controllers
{
    using AirportEf.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    
    public class PlanesController : AbstractController<IPlaneService, PlaneDto, PlaneRequest, int>
    {
        public PlanesController(IPlaneService service) : base(service)
        {
        }
    }
}
