using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stations.DataServiceLayer;
using Stations.Models;

namespace App.Controllers
{
    [Route("Api/Income")]
    [ApiController]
    public class IncomeController : Controller
    {
        IIncomeDSL _incomeDSL;
        public IncomeController(IIncomeDSL incomeDSL)
        {
            this._incomeDSL = incomeDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll(IncomeDTO entity) => Ok(await _incomeDSL.GetAll(entity));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _incomeDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(IncomeDTO model) => Ok(await _incomeDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(IncomeDTO model) => Ok(await _incomeDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _incomeDSL.Delete(id));
        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _incomeDSL.GetAllLite());
        [HttpGet, Route("GetIncomesByStationId/{stationId}")]
        public async Task<IActionResult> GetIncomesByStationId(long stationId) => Ok(await _incomeDSL.GetIncomesByStationId(stationId));
    }
}