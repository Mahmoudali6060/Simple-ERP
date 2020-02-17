using Data.Entities.Credit;
using Shared.DataAccessLayer;
using Shared.Entities.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public interface ISelectorDetailDAL : ICRUDOperationsDAL<SelectorDetail>
    {
        Task<IEnumerable<SelectorDetailDTO>> GetAllBySelectorId(long selectorId);

    }
}
