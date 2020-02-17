using Account.DataAccessLayer;
using Account.DataServiceLayer;
using Accouting.DataAccessLayer;
using Accouting.DataServiceLayer;
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

            services.AddTransient<ICategoryDSL, CategoryDSL>();
            services.AddTransient<ICategoryDAL, CategoryDAL>();
            services.AddTransient<ITransactionDSL, TransactionDSL>();
            services.AddTransient<ITransactionDAL, TransactionDAL>();

            services.AddTransient<IDriverDSL, DriverDSL>();
            services.AddTransient<IDriverDAL, DriverDAL>();

            services.AddTransient<ITransferDSL, TransferDSL>();
            services.AddTransient<ITransferDAL, TransferDAL>();

            services.AddTransient<ISelectorDSL, SelectorDSL>();
            services.AddTransient<ISelectorDAL, SelectorDAL>();
            services.AddTransient<ISelectorDetailDSL, SelectorDetailDSL>();
            services.AddTransient<ISelectorDetailDAL, SelectorDetialDAL>();

            services.AddTransient<IReaperDSL, ReaperDSL>();
            services.AddTransient<IReaperDAL, ReaperDAL>();
            services.AddTransient<IReaperDetailDSL, ReaperDetailDSL>();
            services.AddTransient<IReaperDetailDAL, ReaperDetailDAL>();

            services.AddTransient<IDebitBorrowDSL, DebitBorrowDSL>();
            services.AddTransient<IDebitBorrowDAL, DebitBorrowDAL>();
            services.AddTransient<IDebitCurrentDSL, DebitCurrentDSL>();
            services.AddTransient<IDebitCurrentDAL, DebitCurrentDAL>();
            services.AddTransient<ISafeDSL, SafeDSL>();
            services.AddTransient<ISafeDAL, SafeDAL>();

            services.AddTransient<ICreditBorrowDSL, CreditBorrowDSL>();
            services.AddTransient<ICreditBorrowDAL, CreditBorrowDAL>();
            services.AddTransient<ICreditCurrentDSL, CreditCurrentDSL>();
            services.AddTransient<ICreditCurrentDAL, CreditCurrentDAL>();
            services.AddTransient<ISalaryDSL, SalaryDSL>();
            services.AddTransient<ISalaryDAL, SalaryDAL>();

        }
    }
}
