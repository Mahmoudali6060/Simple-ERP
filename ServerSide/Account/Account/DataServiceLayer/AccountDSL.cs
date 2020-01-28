using Account.DataAccessLayer;
using Account.Models;
using Account.RepositoryLayer;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.DataServiceLayer
{
    public class AccountDSL : IAccountDSL
    {
        IAccountDAL _accountDAL;
        public AccountDSL(IAccountDAL accountDAL)
        {
            this._accountDAL = accountDAL;
        }

        public Task<IdentityResult> Register(RegisterRequestViewModel model)
        {
            var user = AccountHelper.MapAppUser(model);
            return _accountDAL.Register(user, model.Password);
        }

        public Task<RegisterResponseViewModel> AddToken(RegisterRequestViewModel model)
        {
            var user = AccountHelper.MapAppUser(model);
            return _accountDAL.AddToken(user);
        }

        public string AddToken(LoginModel model)
        {
            return _accountDAL.AddToken(model);
        }
    }
}
