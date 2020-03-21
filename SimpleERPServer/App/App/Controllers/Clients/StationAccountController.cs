using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;

namespace App.Controllers.Suppliers
{
    [Route("Api/StationAccount")]
    [ApiController]
    public class StationAccountController : Controller
    {
        IStationAccountDSL _stationAccountDSL;
        public StationAccountController(IStationAccountDSL stationAccountDSL)
        {
            this._stationAccountDSL = stationAccountDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _stationAccountDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _stationAccountDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(StationAccountDTO model) => Ok(await _stationAccountDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _stationAccountDSL.Delete(id));
        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _stationAccountDSL.GetAllLite());
        [HttpPost, Route("GetStationAccountsByStationId/{stationId}")]
        public async Task<IActionResult> GetStationAccountsByStationId(long stationId, [FromBody]DataSource dataSource) => Ok(await _stationAccountDSL.GetAllByStationId(stationId, dataSource));
    }
}