

using Account.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
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
