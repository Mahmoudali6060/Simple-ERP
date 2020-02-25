


using Data.Entities;
using Data.Entities.Credit;
using Data.Entities.Debit;
using Shared.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public interface ISafeDAL : ICRUDOperationsDAL<Safe>
    {
        FarmAccount GetFarmAccountBySafeId(long safeId);
        StationAccount GetStationAccountBySafeId(long safeId);
        DriverAccount GetDriverAccountBySafeId(long safeId);
        SelectorAccount GetSelectorAccountBySafeId(long safeId);
        ReaperAccount GetReaperAccountBySafeId(long safeId);
    }
}
