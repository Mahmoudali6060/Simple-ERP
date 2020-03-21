using Account.DataAccessLayer;
using Account.Models;
using Account.RepositoryLayer;
using Data.Entities.Shared;
using Microsoft.AspNetCore.Identity;
using Setting.DataServiceLayer;
using Shared.Entities;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Account.DataServiceLayer
{
    public class AccountDSL : IAccountDSL
    {
        IAccountDAL _accountDAL;
        ISettingDSL _settingDSL;

        public AccountDSL(IAccountDAL accountDAL, ISettingDSL settingDSL)
        {
            this._accountDAL = accountDAL;
            _settingDSL = settingDSL;
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

        public  bool IsValidClient()
        {
            try
            {
                string curFile = @"C:\users\doc.txt";
                List<Settings> settings =  _settingDSL.GetSettings();
                if (File.Exists(curFile) && settings[0].ExpiryDate.Date > DateTime.Now.Date)
                {
                    return true;
                }
                return false;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
