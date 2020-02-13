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

namespace App.Controllers
{
    [Route("Api/ReaperDetail")]
    [ApiController]
    public class ReaperDetailController : Controller
    {
        IReaperDetailDSL _reaperDetailDSL;
        public ReaperDetailController(IReaperDetailDSL reaperDetailDSL)
        {
            this._reaperDetailDSL = reaperDetailDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _reaperDetailDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _reaperDetailDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(ReaperDetailDTO model) => Ok(await _reaperDetailDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _reaperDetailDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite()
        {
            try
            {
                return Ok(await _reaperDetailDSL.GetAllLite());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}