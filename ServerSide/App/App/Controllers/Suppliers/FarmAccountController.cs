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
    [Route("Api/FarmAccount")]
    [ApiController]
    public class FarmAccountController : Controller
    {
        IFarmAccountDSL _farmAccountDSL;
        public FarmAccountController(IFarmAccountDSL farmAccountDSL)
        {
            this._farmAccountDSL = farmAccountDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _farmAccountDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _farmAccountDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(FarmAccountDTO model) => Ok(await _farmAccountDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _farmAccountDSL.Delete(id));
        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _farmAccountDSL.GetAllLite());
        [HttpPost, Route("GetFarmAccountsByFarmId/{farmId}")]
        public async Task<IActionResult> GetFarmAccountsByFarmId(long farmId, [FromBody]DataSource dataSource) => Ok(await _farmAccountDSL.GetAllByFarmId(farmId, dataSource));
    }
}