namespace Airport.WebApi.Controllers
{
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
        public virtual async Task<ActionResult<bool>> GetById()
        {
            var result = await service.DownloadCrewsAsync();

            if (!result)
            {
                return BadRequest("Call Remote API for Crew data was unsuccessful");
            }

            return Ok();
        }
    }
}
