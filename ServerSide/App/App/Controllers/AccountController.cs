using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityServer4.Services;
using System.Linq;
using System;
using IdentityServer4.Stores;
using IdentityServer4.Models;
using IdentityServer4.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Account.Models;
using Account.DataServiceLayer;
using Shared.Entities;

namespace App.Controllers
{

    [Route("Api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        IAccountDSL _accountDSL;

        public AccountController(IAccountDSL accountDSL)
        {
            _accountDSL = accountDSL;
        }


        //GET api/values
        [HttpPost, Route("Login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.UserName == "johndoe" && user.Password == "def@123")
            {
                var tokenString = _accountDSL.AddToken(user);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _accountDSL.Register(model);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(await _accountDSL.AddToken(model));
        }
    }
}
