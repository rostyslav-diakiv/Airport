namespace Airport.WebApi.Controllers
{
    using System.Collections.Generic;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    public class StewardessesController : AbstractController<IStewardessService, StewardessDto, StewardessRequest, int>
    {
        public StewardessesController(IMapper mapper, IStewardessService service) : base(mapper, service)
        {
        }
        //private readonly IMapper mapper;
        //private readonly IStewardessService service;

        //public StewardessesController(IMapper mapper, IStewardessService service)
        //{
        //    mapper = mapper;
        //    service = service;
        //}

        //// GET: api/Stewardesses
        //[HttpGet]
        //public ActionResult<IEnumerable<StewardessDto>> Get()
        //{
        //    var dtos = service.GetAllStewardesses();
        //    if (!dtos.Any())
        //    {
        //        return NoContent();
        //    }

        //    return Ok(dtos);
        //}

        //// GET: api/Stewardesses/5
        //[HttpGet("{id}", Name = "GetStewardess")]
        //public ActionResult<StewardessDto> Get(int id)
        //{
        //    var dto = service.GetStewardessById(id);
        //    if (dto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dto);
        //}

        //// POST: api/Stewardesses
        //[HttpPost]
        //public ActionResult<StewardessDto> Post([FromBody] StewardessRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var dto = service.CreateStewardess(request);
        //    if (dto == null)
        //    {
        //        return StatusCode(500);
        //    }

        //    var host = HttpContext.Request.Host;
        //    var path = HttpContext.Request.Path;
        //    var scheme = HttpContext.Request.Scheme;
        //    return Created(new Uri($"{scheme}://{host.Value}{path.Value}/{dto.Id}"),  dto);
        //}

        //// PUT: api/Stewardesses/5
        //[HttpPut("{id}")]
        //public ActionResult<StewardessDto> Put([FromRoute] int id, [FromBody] StewardessRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var dto = service.UpdateStewardessById(request, id);
        //    if (dto == null)
        //    {
        //        return StatusCode(500);
        //    }

        //    return Ok(dto);
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public ActionResult<bool> Delete(int id)
        //{
        //    var res = service.DeleteStewardessById(id);
        //    if (res)
        //    {
        //        return NoContent();
        //    }

        //    return NotFound();
        //}
    }
}
