using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Airport.Common.Interfaces.Entities;

    using AirportEf.BLL.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<TService, TDto, TRequest, TKey> : ControllerBase 
                                where TService : IService<TDto, TRequest, TKey> 
                                where TDto : IEntity<TKey>
    {
        protected readonly TService service;

        protected AbstractController(TService service)
        {
            this.service = service;
        }

        // GET: api/EntityName
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDto>>> Get()
        {
            var dtos = await service.GetAllEntitiesAsync();
            if (!dtos.Any())
            {
                return NoContent();
            }

            return Ok(dtos);
        }

        // GET: api/EntityName/5
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> GetById(TKey id)
        {
            var dto = await service.GetEntityByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // POST: api/EntityName
        [HttpPost]
        public virtual async Task<ActionResult<TDto>> Create([FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = await service.CreateEntityAsync(request);
            if (dto == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetById", new { id = dto.Id }, dto);
        }

        // PUT: api/EntityName/5
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TDto>> Update([FromRoute] TKey id, [FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.UpdateEntityByIdAsync(request, id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/EntityName/5
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> Delete(TKey id)
        {
            var result = await service.DeleteEntityByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
