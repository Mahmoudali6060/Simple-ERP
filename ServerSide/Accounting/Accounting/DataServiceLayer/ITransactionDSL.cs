using Shared.DataServiceLayer;
using Shared.Entities.Credit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System.Threading.Tasks;

namespace Accouting.DataServiceLayer
{
    public interface ITransactionDSL : ICRUDOperationsDSL<TransactionDTO>
    {
        Task<IncomeDTO> GetIncomeByTransactionId(long transactioId);
        Task<OutcomeDTO> GetOutcomtByTransactionId(long transactioId);
        Task<TransferDTO> GetTransferByTransactionId(long transactioId);
        Task<SelectorDTO> GetSelectorByTransactionId(long transactioId);
        Task<ReaperDetailDTO> GetReaperDetailByTransactionId(long transactioId);
    }
}
