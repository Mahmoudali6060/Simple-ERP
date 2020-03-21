using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;

namespace App.Controllers.Suppliers
{
    [Route("Api/DriverAccount")]
    [ApiController]
    public class DriverAccountController : Controller
    {
        IDriverAccountDSL _driverAccountDSL;
        public DriverAccountController(IDriverAccountDSL driverAccountDSL)
        {
            this._driverAccountDSL = driverAccountDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _driverAccountDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _driverAccountDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(DriverAccountDTO model) => Ok(await _driverAccountDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _driverAccountDSL.Delete(id));
        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _driverAccountDSL.GetAllLite());
        [HttpPost, Route("GetDriverAccountsByDriverId/{driverId}")]
        public async Task<IActionResult> GetDriverAccountsByDriverId(long driverId, [FromBody]DataSource dataSource) => Ok(await _driverAccountDSL.GetAllByDriverId(driverId,dataSource));
    }
}