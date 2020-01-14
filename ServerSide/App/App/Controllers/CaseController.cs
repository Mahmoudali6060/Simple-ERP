using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case.DataServiceLayer;
using Case.DTOs;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{

    public class CaseController : Controller
    {
        ICaseDSL _caseDSL;
        public CaseController(ICaseDSL caseDSL)
        {
            this._caseDSL = caseDSL;
        }

        [HttpGet]
        [Route("api/Case/GetAll")]
        public IActionResult GetAll() => Ok(_caseDSL.GetAll());

        //[HttpGet]
        //public IActionResult GetCaseTypes() => Ok(_caseDSL.GetCaseTypes());
        //[HttpGet]
        //public IActionResult GetByStructureId(int id) => Ok(_caseDSL.GetByStructureId(id));

        [HttpPost]
        public IActionResult Add(CasesDTO model) => Ok(_caseDSL.Add(model));

        [HttpPost]
        public IActionResult Uodate(CasesDTO model) => Ok(_caseDSL.Update(model));

        [HttpDelete]
        public IActionResult Delete(int id) => Ok(_caseDSL.Delete(id));
    }
}