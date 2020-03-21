


using Data.Entities.Credit;
using Data.Entities.Debit;
using Shared.DataAccessLayer;
using Shared.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public interface IStationAccountDAL : ICRUDOperationsDAL<StationAccount>
    {
        Task<IEnumerable<StationAccount>> GetAllByStationId(long stationId);

    }
}
