using Stations.Models;
using Shared.DataServiceLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stations.DataServiceLayer
{
    public interface IIncomeDSL : ICRUDOperationsDSL<IncomeDTO>
    {
        Task<ResponseEntityList<IncomeDTO>> GetIncomesByStationId(long stationId);

    }
}
