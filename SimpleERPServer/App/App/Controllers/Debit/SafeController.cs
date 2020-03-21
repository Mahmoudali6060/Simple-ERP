using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accouting.DataServiceLayer;
using Clients.DataServiceLayer;
using Data.Entities.Debit;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Credit
{
    [Route("Api/Safe")]
    [ApiController]
    public class SafeController : Controller
    {
        ISafeDSL _safeDSL;
        public SafeController(ISafeDSL safeDSL)
        {
            this._safeDSL = safeDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _safeDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _safeDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(SafeDTO model) => Ok(await _safeDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _safeDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _safeDSL.GetAllLite());
    }
}