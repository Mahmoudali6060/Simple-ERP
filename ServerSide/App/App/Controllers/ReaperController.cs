using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("Api/Reaper")]
    [ApiController]
    public class ReaperController : Controller
    {
        IReaperDSL _reaperDSL;
        public ReaperController(IReaperDSL reaperDSL)
        {
            this._reaperDSL = reaperDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll(ReaperDTO entity) => Ok(await _reaperDSL.GetAll(entity));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _reaperDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(ReaperDTO model) => Ok(await _reaperDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(ReaperDTO model) => Ok(await _reaperDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _reaperDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite()
        {
            try
            {
                return Ok(await _reaperDSL.GetAllLite());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}