using Data.Entities.Debit;
using Shared.DataServiceLayer;
using Shared.Entities.Credit;
using Shared.Entities.Debit;
using System.Threading.Tasks;

namespace Accouting.DataServiceLayer
{
    public interface ISafeDSL : ICRUDOperationsDSL<SafeDTO>
    {
        FarmAccountDTO GetFarmAccountBySafeId(long safeId);
        StationAccountDTO GetStationAccountBySafeId(long safeId);
        DriverAccountDTO GetDriverAccountBySafeId(long safeId);
        SelectorAccountDTO GetSelectorAccountBySafeId(long safeId);
        ReaperAccountDTO GetReaperAccountBySafeId(long safeId);
    }
}
