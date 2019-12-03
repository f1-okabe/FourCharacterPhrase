using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourCharacterPhrase.Server.Dao;
using FourCharacterPhrase.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourCharacterPhrase.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CellsController : ControllerBase
    {
        [HttpGet]
        public List<CellEntity> Get()
        {
            var daoD_Cell = new DaoD_Cell();

            var daoD_AnswerNumber = new DaoD_AnswerNumber();
            var answerNumber = daoD_AnswerNumber.GetAnswerNumberList().OrderBy(m => m.Count).ThenByDescending(m => m.ElapsedTime).FirstOrDefault();

            return daoD_Cell.GetCellList(answerNumber.Name).OrderBy(m => m.No).ToList();
        }

        [HttpPost]
        public void Post([FromBody] List<CellEntity> value)
        {
            var daoD_Cell = new DaoD_Cell();
            daoD_Cell.Save(value);
        }

    }
}