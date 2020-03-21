

using Account.Models;
using Data.Entities.Shared;
using Microsoft.AspNetCore.Identity;
using Shared.Entities.Shared;
using System.Threading.Tasks;

namespace Account.DataAccessLayer
{
    public interface IAccountDAL
    {
        Task<IdentityResult> Register(AppUser user, string password);
        Task<RegisterResponseViewModel> AddToken(AppUser user);
        string AddToken(LoginModel model);
    }
}
