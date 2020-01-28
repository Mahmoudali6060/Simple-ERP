using Account.Models;
using Data.Constants;
using Data.Entities;
using Data.Entities.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shared.Entities;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Account.DataAccessLayer
{
    public class AccountDAL : IAccountDAL
    {
        //private LifeSafeDbContext _context;
        //private DbSet<Client> _entity;
        private readonly UserManager<AppUser> _userManager;

        public AccountDAL(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<RegisterResponseViewModel> AddToken(AppUser user)
        {
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("name", user.FirstName));
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Roles.Consumer));
            return new RegisterResponseViewModel(user);
        }

        public string AddToken(LoginModel model)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:54095",
                audience: "http://localhost:54095",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
