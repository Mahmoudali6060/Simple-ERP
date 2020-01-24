


using Data.Entities;
using Shared.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stations.DataAccessLayer
{
    public interface IIncomeDAL : ICRUDOperationsDAL<Income>
    {
        Task<IEnumerable<Income>> GetIncomesByStationId(long stationId);
    }
}
