using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accouting.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Credit
{
    [Route("Api/CreditCurrent")]
    [ApiController]
    public class CreditCurrentController : Controller
    {
        ICreditCurrentDSL _creditCurrentDSL;
        public CreditCurrentController(ICreditCurrentDSL creditCurrentDSL)
        {
            this._creditCurrentDSL = creditCurrentDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _creditCurrentDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _creditCurrentDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(CreditCurrentDTO model) => Ok(await _creditCurrentDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _creditCurrentDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _creditCurrentDSL.GetAllLite());
    }
}