


using Data.Entities;
using Data.Entities.Debit;
using Shared.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public interface IOutcomeDAL : ICRUDOperationsDAL<Outcome>
    {
        Task<IEnumerable<Outcome>> GetOutcomesByStationId(long stationId);
    }
}
