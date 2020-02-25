using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accouting.DataServiceLayer;
using Data.Entities.Shared;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Accounting
{
    [Route("Api/AccountTree")]
    [ApiController]
    public class AccountTreeController : Controller
    {
        IAccountTreeDSL _accountTreeDSL;
        public AccountTreeController(IAccountTreeDSL accountTreeDSL)
        {
            this._accountTreeDSL = accountTreeDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _accountTreeDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _accountTreeDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(AccountTree model) => Ok(await _accountTreeDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _accountTreeDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _accountTreeDSL.GetAllLite());
    }
}