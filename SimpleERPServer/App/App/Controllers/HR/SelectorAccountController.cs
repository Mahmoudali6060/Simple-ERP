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
    [Route("Api/SelectorAccount")]
    [ApiController]
    public class SelectorAccountController : Controller
    {
        ISelectorAccountDSL _selectorAccountDSL;
        public SelectorAccountController(ISelectorAccountDSL selectorAccountDSL)
        {
            this._selectorAccountDSL = selectorAccountDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _selectorAccountDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _selectorAccountDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(SelectorAccountDTO model) => Ok(await _selectorAccountDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _selectorAccountDSL.Delete(id));
        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _selectorAccountDSL.GetAllLite());
        [HttpPost, Route("GetSelectorAccountsBySelectorId/{selectorId}")]
        public async Task<IActionResult> GetSelectorAccountsBySelectorId(long selectorId, [FromBody]DataSource dataSource) => Ok(await _selectorAccountDSL.GetAllBySelectorId(selectorId, dataSource));
    }
}