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
    [Route("Api/Income")]
    [ApiController]
    public class IncomeController : Controller
    {
        IIncomeDSL _incomeDSL;
        public IncomeController(IIncomeDSL incomeDSL)
        {
            this._incomeDSL = incomeDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _incomeDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _incomeDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(IncomeDTO model) => Ok(await _incomeDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _incomeDSL.Delete(id));
        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _incomeDSL.GetAllLite());
        [HttpPost, Route("GetIncomesByFarmId/{farmId}")]
        public async Task<IActionResult> GetIncomesByFarmId(long farmId, DataSource dataSource) => Ok(await _incomeDSL.GetIncomesByFarmId(farmId, dataSource));
    }
}