


using Data.Entities.Credit;
using Shared.DataAccessLayer;
using Shared.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public interface ISelectorAccountDAL : ICRUDOperationsDAL<SelectorAccount>
    {
        Task<IEnumerable<SelectorAccount>> GetAllBySelectorId(long selectorId);
    }
}
