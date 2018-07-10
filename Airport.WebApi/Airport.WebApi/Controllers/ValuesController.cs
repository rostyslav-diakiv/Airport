using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Airport.WebApi.Controllers
{
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var st1 = new Stewardess()
                          {
                              Crews = new List<ICrew>(),
                              DateOfBirth = new DateTime(1997, 11, 11),
                              FirstName = "Lisa",
                              SecondName = "Ofdfd",
                              Id = 1
                          };

            var st2 = _mapper.Map<Stewardess>(st1);

            // It works

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
