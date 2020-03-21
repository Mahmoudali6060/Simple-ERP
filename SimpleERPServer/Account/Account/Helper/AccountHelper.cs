using Account.DataAccessLayer;
using Account.Models;
using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.RepositoryLayer
{
    public class AccountHelper
    {
        //public AccountHelper(IAccounttDAL accountDAL)
        //{

        //}

        public static AppUser MapAppUser(RegisterRequestViewModel model)
        {
            return new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email

            };
        }

    }
}
