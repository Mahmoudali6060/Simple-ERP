﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Debit;

namespace App.Controllers
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
        public async Task<IActionResult> GetAll(OutcomeDTO entity) => Ok(await _outcomeDSL.GetAll(entity));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _outcomeDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(OutcomeDTO model) => Ok(await _outcomeDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(OutcomeDTO model) => Ok(await _outcomeDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _outcomeDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _outcomeDSL.GetAllLite());

        [HttpGet, Route("GetOutcomesByStationId/{stationId}")]
        public async Task<IActionResult> GetOutcomesByStationId(long stationId) => Ok(await _outcomeDSL.GetOutcomesByStationId(stationId));
    }
}