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
    [Route("Api/ReaperAccount")]
    [ApiController]
    public class ReaperAccountController : Controller
    {
        IReaperAccountDSL _reaperAccountDSL;
        public ReaperAccountController(IReaperAccountDSL reaperAccountDSL)
        {
            this._reaperAccountDSL = reaperAccountDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _reaperAccountDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _reaperAccountDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(ReaperAccountDTO model) => Ok(await _reaperAccountDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _reaperAccountDSL.Delete(id));
        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _reaperAccountDSL.GetAllLite());
        [HttpPost, Route("GetReaperAccountsByReaperId/{reaperId}")]
        public async Task<IActionResult> GetReaperAccountsByReaperId(long reaperId, [FromBody]DataSource dataSource) => Ok(await _reaperAccountDSL.GetAllByReaperId(reaperId, dataSource));
    }
}