namespace Airport.WebApi.Controllers
{
    using System.Text;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.BLL.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    public class CrewsController : AbstractController<ICrewService, CrewDto, CrewRequest, int>
    {
        public CrewsController(ICrewService service) : base(service)
        {
        }

        // GET: api/Crews/Seed
        [HttpGet("Seed")]
        public virtual async Task<ActionResult> GetById()
        {
            await service.DownloadCrewsAsync();

            return Ok();
        }
    }
}
