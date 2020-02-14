using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accouting.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Debit
{
    [Route("Api/DebitCurrent")]
    [ApiController]
    public class DebitCurrentController : Controller
    {
        IDebitCurrentDSL _debitCurrentDSL;
        public DebitCurrentController(IDebitCurrentDSL debitCurrentDSL)
        {
            this._debitCurrentDSL = debitCurrentDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _debitCurrentDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _debitCurrentDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(DebitCurrentDTO model) => Ok(await _debitCurrentDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _debitCurrentDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _debitCurrentDSL.GetAllLite());
    }
}