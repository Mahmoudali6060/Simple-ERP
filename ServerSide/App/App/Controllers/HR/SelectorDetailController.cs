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
    [Route("Api/SelectorDetail")]
    [ApiController]
    public class SelectorDetailController : Controller
    {
        ISelectorDetailDSL _selectorDetailDSL;
        public SelectorDetailController(ISelectorDetailDSL selectorDSL)
        {
            this._selectorDetailDSL = selectorDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _selectorDetailDSL.GetAll(dataSource));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _selectorDetailDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(SelectorDetailDTO model) => Ok(await _selectorDetailDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _selectorDetailDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite()
        {
            try
            {
                return Ok(await _selectorDetailDSL.GetAllLite());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("GetAllBySelectorId/{SelectorId}")]
        public async Task<IActionResult> GetAllBySelectorId(long selectorId, [FromBody]DataSource dataSource) => Ok(await _selectorDetailDSL.GetAllBySelectorId(selectorId, dataSource));

    }
}