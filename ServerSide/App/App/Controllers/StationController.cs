using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stations.DataServiceLayer;
using Stations.Models;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<IActionResult> GetAll(StationDTO entity) => Ok(await _stationDSL.GetAll(entity));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _stationDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(StationDTO model) => Ok(await _stationDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(StationDTO model) => Ok(await _stationDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _stationDSL.Delete(id));
    }
}