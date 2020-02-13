


using Data.Entities.Credit;
using Data.Entities.Debit;
using Data.Entities.Shared;
using Shared.DataAccessLayer;
using Shared.Entities.Credit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public interface ITransactionDAL : ICRUDOperationsDAL<Transaction>
    {
        new Task<IEnumerable<TransactionDTO>> GetAll();
        Task<Income> GetIncomeByTransactionId(long transactioId);
        Task<Outcome> GetOutcomtByTransactionId(long transactioId);
        Task<Transfer> GetTransferByTransactionId(long transactioId);
        Task<Selector> GetSelectorByTransactionId(long transactioId);
        Task<ReaperDetail> GetReaperDetailByTransactionId(long transactioId);
    }
}
