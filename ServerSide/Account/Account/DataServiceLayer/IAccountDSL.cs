using Account.Models;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.DataServiceLayer
{
    public interface IAccountDSL
    {
        Task<IdentityResult> Register(RegisterRequestViewModel model);
        Task<RegisterResponseViewModel> AddToken(RegisterRequestViewModel model);
        string AddToken(LoginModel model);

    }
}
