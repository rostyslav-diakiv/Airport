using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using Airport.BLL.Interfaces;
    using Airport.Common.Interfaces.Entities;
    using Airport.Common.Requests;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore.Internal;

    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<TService, TDto, TRequest, TKey> : ControllerBase where TService : IService<TDto, TRequest, TKey> where TDto : IEntity<TKey>
    {
        protected readonly IMapper mapper;
        protected readonly TService service;

        protected AbstractController(IMapper mapper, TService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        // GET: api/EntityName
        [HttpGet]
        public virtual ActionResult<IEnumerable<TDto>> Get([FromQuery] Filter filter)
        {
            var dtos = service.GetAllEntity(filter);
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        // GET: api/EntityName/5
        [HttpGet("{id}")]
        public virtual ActionResult<TDto> GetById(TKey id)
        {
            var dto = service.GetEntityById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: api/EntityName
        [HttpPost]
        public virtual ActionResult<TDto> Create([FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = service.CreateEntity(request);
            if (dto == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dto.Id }, dto);
        }

        // PUT: api/EntityName/5
        [HttpPut("{id}")]
        public virtual ActionResult<TDto> Update([FromRoute] TKey id, [FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = service.UpdateEntityById(request, id);
            if (dto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/EntityName/5
        [HttpDelete("{id}")]
        public virtual ActionResult<bool> Delete(TKey id)
        {
            var res = service.DeleteEntityById(id);
            if (!res)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
