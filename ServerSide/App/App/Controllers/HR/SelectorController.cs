using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.HR
{
    [Route("Api/Selector")]
    [ApiController]
    public class SelectorController : Controller
    {
        ISelectorDSL _selectorDSL;
        public SelectorController(ISelectorDSL selectorDSL)
        {
            this._selectorDSL = selectorDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _selectorDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _selectorDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(SelectorDTO model) => Ok(await _selectorDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _selectorDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite()
        {
            try
            {
                return Ok(await _selectorDSL.GetAllLite());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}