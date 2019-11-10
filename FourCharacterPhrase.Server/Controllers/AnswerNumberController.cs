using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourCharacterPhrase.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FourCharacterPhrase.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnswerNumberController : ControllerBase
    {
        // GET: api/AnswerNumber
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AnswerNumber/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/AnswerNumber
        [HttpPost]
        public void Post([FromBody] AnswerNumberEntity value)
        {
            Console.WriteLine(JsonConvert.SerializeObject(value));
        }

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    Console.WriteLine(value);
        //}

        // PUT: api/AnswerNumber/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
