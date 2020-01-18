using Account.DataAccessLayer;
using Account.DataServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Helper
{
    public class DependencyInjection
    {
        public static void AddTransient(IServiceCollection services)
        {
            services.AddTransient<IAccountDSL, AccountDSL>();
            services.AddTransient<IAccountDAL, AccountDAL>();
        }
    }
}
