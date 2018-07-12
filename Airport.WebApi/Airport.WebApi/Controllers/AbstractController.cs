using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using Airport.Common.Interfaces.Entities;

    using AirportEf.BLL.Interfaces;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore.Internal;

    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<TService, TDto, TRequest, TKey> : ControllerBase where TService : IService<TDto, TRequest, TKey> where TDto : IEntity<TKey>
    {
        protected readonly IMapper _mapper;
        protected readonly TService _service;

        protected AbstractController(IMapper mapper, TService service)
        {
            _mapper = mapper;
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<TDto>> Get()
        {
            var dtos = _service.GetAllEntity();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }
        
        [HttpGet("{id}", Name = "GetEntity")]
        public ActionResult<TDto> Get(TKey id)
        {
            var dto = _service.GetEntityById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
        
        [HttpPost]
        public ActionResult<TDto> Create([FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _service.CreateEntity(request);
            if (dto == null)
            {
                return StatusCode(500);
            }

            return CreatedAtRoute("GetEntity", new { id = dto.Id }, dto);
        }

        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public ActionResult<TDto> Update([FromRoute] TKey id, [FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _service.UpdateEntityById(request, id);
            if (dto == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(TKey id)
        {
            var res = _service.DeleteEntityById(id);
            if (!res)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
