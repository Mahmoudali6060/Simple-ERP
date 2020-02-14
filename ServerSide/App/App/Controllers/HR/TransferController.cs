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
    [Route("Api/Transfer")]
    [ApiController]
    public class TransferController : Controller
    {
        ITransferDSL _transferDSL;
        public TransferController(ITransferDSL transferDSL)
        {
            this._transferDSL = transferDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _transferDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _transferDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(TransferDTO model) => Ok(await _transferDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _transferDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _transferDSL.GetAllLite());
    }
}