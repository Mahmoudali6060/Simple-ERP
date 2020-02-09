using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("Api/Driver")]
    [ApiController]
    public class DriverController : Controller
    {
        IDriverDSL _driverDSL;
        public DriverController(IDriverDSL driverDSL)
        {
            this._driverDSL = driverDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _driverDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _driverDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(DriverDTO model) => Ok(await _driverDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(DriverDTO model) => Ok(await _driverDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _driverDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _driverDSL.GetAllLite());
    }
}