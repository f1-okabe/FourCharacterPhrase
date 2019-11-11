using System.Collections.Generic;
using FourCharacterPhrase.Server.Dao;
using FourCharacterPhrase.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FourCharacterPhrase.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnswerNumberController : ControllerBase
    {
        // GET: api/AnswerNumber
        [HttpGet]
        public IEnumerable<AnswerNumberEntity> Get()
        {
            var daoD_AnswerNumber = new DaoD_AnswerNumber();
            return daoD_AnswerNumber.GetAnswerNumberList();
        }

        //POST: api/AnswerNumber
        [HttpPost]
        public void Post([FromBody] AnswerNumberEntity value)
        {
            var daoD_AnswerNumber = new DaoD_AnswerNumber();
            daoD_AnswerNumber.Save(value);
        }
    }
}
