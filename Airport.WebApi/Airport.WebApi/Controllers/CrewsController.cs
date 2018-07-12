using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using System.Linq;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    public class CrewsController : AbstractController<ICrewService, CrewDto, CrewRequest, int>
    {
        public CrewsController(IMapper mapper, ICrewService service) : base(mapper, service)
        {
        }
        //private readonly IMapper mapper;
        //private readonly ICrewService service;

        //public CrewsController(IMapper mapper, ICrewService service)
        //{
        //    mapper = mapper;
        //    service = service;
        //}

        //// GET: api/Crews
        //[HttpGet]
        //public ActionResult<IEnumerable<CrewDto>> Get()
        //{
        //    var dtos = service.GetAllCrews();
        //    if (!dtos.Any())
        //    {
        //        return NoContent();
        //    }

        //    return Ok(dtos);
        //}

        //// GET: api/Crews/5
        //[HttpGet("{id}", Name = "GetCrew")]
        //public ActionResult<CrewDto> Get(int id)
        //{
        //    var dto = service.GetCrewById(id);
        //    if (dto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dto);
        //}

        //// POST: api/Crews
        //[HttpPost]
        //public ActionResult<CrewDto> Create([FromBody] CrewRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var dto = service.CreateCrew(request);
        //    if (dto == null)
        //    {
        //        return StatusCode(500);
        //    }

        //    return CreatedAtRoute("GetCrew", new { id = dto.Id }, dto);
        //    //var host = HttpContext.Request.Host;
        //    //var path = HttpContext.Request.Path;
        //    //var scheme = HttpContext.Request.Scheme;
        //    //return Created(new Uri($"{scheme}://{host.Value}{path.Value}/{dto.Id}"), dto);
        //}

        //// PUT: api/Crews/5
        //[HttpPut("{id}")]
        //public ActionResult<CrewDto> Update([FromRoute] int id, [FromBody] CrewRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var dto = service.UpdateCrewById(request, id);
        //    if (dto == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/Crews/5
        //[HttpDelete("{id}")]
        //public ActionResult<bool> Delete(int id)
        //{
        //    var res = service.DeleteCrewById(id);
        //    if (!res)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
    }
}
