using Shared.DataServiceLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities.Credit;
using Shared.Entities.Shared;

namespace Supplier.DataServiceLayer
{
    public interface IIncomeDSL : ICRUDOperationsDSL<IncomeDTO>
    {
        Task<Response> GetIncomesByFarmId(long farmId, DataSource dataSource);
    }
}
