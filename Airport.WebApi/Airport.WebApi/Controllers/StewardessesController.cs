using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore.Internal;

    [Route("api/[controller]")]
    [ApiController]
    public class StewardessesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStewardessService _service;

        public StewardessesController(IMapper mapper, IStewardessService service)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET: api/Stewardesses
        [HttpGet]
        public ActionResult<IEnumerable<StewardessDto>> Get()
        {
            var dtos = _service.GetAllStewardesses();

            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        // GET: api/Stewardesses/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<StewardessDto> Get(int id)
        {
            var dto = _service.GetStewardessById(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: api/Stewardesses
        [HttpPost]
        public ActionResult<StewardessDto> Post([FromBody] StewardessRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _service.CreateStewardess(request);

            return Ok(dto);
        }

        // PUT: api/Stewardesses/5
        [HttpPut("{id}")]
        public ActionResult<StewardessDto> Put([FromRoute] int id, [FromBody] StewardessRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _service.UpdateStewardessById(request, id);

            return Ok(dto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
