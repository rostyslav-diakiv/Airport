using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using System;
    using System.Linq;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class CrewsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICrewService _service;

        public CrewsController(IMapper mapper, ICrewService service)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET: api/Crews
        [HttpGet]
        public ActionResult<IEnumerable<CrewDto>> Get()
        {
            var dtos = _service.GetAllCrews();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        // GET: api/Crews/5
        [HttpGet("{id}", Name = "GetCrew")]
        public ActionResult<CrewDto> Get(int id)
        {
            var dto = _service.GetCrewById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: api/Crews
        [HttpPost]
        public ActionResult<CrewDto> Create([FromBody] CrewRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _service.CreateCrew(request);
            if (dto == null)
            {
                return StatusCode(500);
            }

            return CreatedAtRoute("GetCrew", new { id = dto.Id }, dto);
            //var host = HttpContext.Request.Host;
            //var path = HttpContext.Request.Path;
            //var scheme = HttpContext.Request.Scheme;
            //return Created(new Uri($"{scheme}://{host.Value}{path.Value}/{dto.Id}"), dto);
        }

        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public ActionResult<CrewDto> Update([FromRoute] int id, [FromBody] CrewRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _service.UpdateCrewById(request, id);
            if (dto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Crews/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var res = _service.DeleteCrewById(id);
            if (!res)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
