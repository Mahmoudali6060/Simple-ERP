using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farms.DataServiceLayer;
using Farms.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("Api/Farm")]
    [ApiController]
    public class FarmController : Controller
    {
        IFarmDSL _farmDSL;
        public FarmController(IFarmDSL farmDSL)
        {
            this._farmDSL = farmDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll(FarmDTO entity) => Ok(await _farmDSL.GetAll(entity));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _farmDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(FarmDTO model) => Ok(await _farmDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(FarmDTO model) => Ok(await _farmDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _farmDSL.Delete(id));
    }
}