


using Data.Entities.Credit;
using Shared.DataAccessLayer;
using Shared.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public interface IReaperAccountDAL : ICRUDOperationsDAL<ReaperAccount>
    {
        Task<IEnumerable<ReaperAccount>> GetAllByReaperId(long reaperId);
    }
}
