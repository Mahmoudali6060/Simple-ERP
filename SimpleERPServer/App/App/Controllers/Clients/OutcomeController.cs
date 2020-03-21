using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Debit;
using Shared.Entities.Shared;

namespace App.Controllers.Clients
{
    [Route("Api/Outcome")]
    [ApiController]
    public class OutcomeController : Controller
    {
        IOutcomeDSL _outcomeDSL;
        public OutcomeController(IOutcomeDSL outcomeDSL)
        {
            this._outcomeDSL = outcomeDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _outcomeDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _outcomeDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(OutcomeDTO model) => Ok(await _outcomeDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _outcomeDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _outcomeDSL.GetAllLite());

        [HttpPost, Route("GetOutcomesByStationId/{stationId}")]
        public async Task<IActionResult> GetOutcomesByStationId(long stationId, DataSource dataSource) => Ok(await _outcomeDSL.GetOutcomesByStationId(stationId, dataSource));
    }
}