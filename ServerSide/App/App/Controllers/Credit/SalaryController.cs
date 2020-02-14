using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accouting.DataServiceLayer;
using Clients.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Credit
{
    [Route("Api/Salary")]
    [ApiController]
    public class SalaryController : Controller
    {
        ISalaryDSL _salaryDSL;
        public SalaryController(ISalaryDSL salaryDSL)
        {
            this._salaryDSL = salaryDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _salaryDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _salaryDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(SalaryDTO model) => Ok(await _salaryDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _salaryDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _salaryDSL.GetAllLite());
    }
}