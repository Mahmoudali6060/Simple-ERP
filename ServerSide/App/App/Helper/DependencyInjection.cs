using Account.DataAccessLayer;
using Account.DataServiceLayer;
using Farms.DataAccessLayer;
using Farms.DataServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using Stations.DataAccessLayer;
using Stations.DataServiceLayer;
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
            services.AddTransient<IStationDSL, StationDSL>();
            services.AddTransient<IStationDAL, StationDAL>();
        }
    }
}
