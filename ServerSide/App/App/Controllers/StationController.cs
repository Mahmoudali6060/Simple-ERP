using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Debit;
using Clients.DataServiceLayer;
using Shared.Entities.Shared;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("Api/Station")]
    [ApiController]
    public class StationController : Controller
    {
        IStationDSL _stationDSL;
        public StationController(IStationDSL stationDSL)
        {
            this._stationDSL = stationDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _stationDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _stationDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(StationDTO model) => Ok(await _stationDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _stationDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _stationDSL.GetAllLite());
    }
}