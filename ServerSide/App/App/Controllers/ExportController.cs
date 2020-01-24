using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farms.DataServiceLayer;
using Farms.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("Api/Export")]
    [ApiController]
    public class ExportController : Controller
    {
        IExportDSL _exportDSL;
        public ExportController(IExportDSL exportDSL)
        {
            this._exportDSL = exportDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll(ExportDTO entity) => Ok(await _exportDSL.GetAll(entity));

        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _exportDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(ExportDTO model) => Ok(await _exportDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(ExportDTO model) => Ok(await _exportDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _exportDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _exportDSL.GetAllLite());

        [HttpGet, Route("GetExportsByFarmId/{farmId}")]
        public async Task<IActionResult> GetExportsByFarmId(long farmId) => Ok(await _exportDSL.GetExportsByFarmId(farmId));
    }
}