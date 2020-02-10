


using Data.Entities.Shared;
using Shared.DataAccessLayer;
using Shared.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accouting.DataAccessLayer
{
    public interface ITransactionDAL : ICRUDOperationsDAL<Transaction>
    {
        new Task<IEnumerable<TransactionDTO>> GetAll();
    }
}
