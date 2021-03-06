﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.HR
{
    [Route("Api/Reaper")]
    [ApiController]
    public class ReaperController : Controller
    {
        IReaperDSL _reaperDSL;
        public ReaperController(IReaperDSL reaperDSL)
        {
            this._reaperDSL = reaperDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _reaperDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _reaperDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(ReaperDTO model) => Ok(await _reaperDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _reaperDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite()
        {
            try
            {
                return Ok(await _reaperDSL.GetAllLite());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}