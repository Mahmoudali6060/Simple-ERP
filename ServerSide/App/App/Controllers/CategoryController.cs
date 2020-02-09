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

namespace App.Controllers
{
    [Route("Api/Category")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryDSL _categoryDSL;
        public CategoryController(ICategoryDSL categoryDSL)
        {
            this._categoryDSL = categoryDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _categoryDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _categoryDSL.GetById(id));

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add(CategoryDTO model) => Ok(await _categoryDSL.Add(model));

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(CategoryDTO model) => Ok(await _categoryDSL.Update(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _categoryDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _categoryDSL.GetAllLite());
    }
}