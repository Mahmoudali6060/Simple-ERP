﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accouting.DataServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using Supplier.DataServiceLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers.Accounting
{
    [Route("Api/Transaction")]
    [ApiController]
    public class TransactionController : Controller
    {
        ITransactionDSL _transactionDSL;
        public TransactionController(ITransactionDSL transactionDSL)
        {
            this._transactionDSL = transactionDSL;
        }

        [HttpPost, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]DataSource dataSource) => Ok(await _transactionDSL.GetAll(dataSource));


        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(long id) => Ok(await _transactionDSL.GetById(id));

        [HttpPost, Route("Save")]
        public async Task<IActionResult> Save(TransactionDTO model) => Ok(await _transactionDSL.Save(model));

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _transactionDSL.Delete(id));

        [HttpGet, Route("GetAllLite")]
        public async Task<IActionResult> GetAllLite() => Ok(await _transactionDSL.GetAllLite());
    }
}