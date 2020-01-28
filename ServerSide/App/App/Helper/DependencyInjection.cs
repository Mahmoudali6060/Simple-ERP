using Account.DataAccessLayer;
using Account.DataServiceLayer;
using Clients.DataAccessLayer;
using Clients.DataServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using Supplier.DataAccessLayer;
using Supplier.DataServiceLayer;
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
            services.AddTransient<IFarmDSL, FarmDSL>();
            services.AddTransient<IFarmDAL, FarmDAL>();
            services.AddTransient<IIncomeDSL, IncomeDSL>();
            services.AddTransient<IIncomeDAL, IncomeDAL>();
            services.AddTransient<IStationDSL, StationDSL>();
            services.AddTransient<IStationDAL, StationDAL>();
            services.AddTransient<IOutcomeDSL, OutcomeDSL>();
            services.AddTransient<IOutcomeDAL, OutcomeDAL>();
        }
    }
}
