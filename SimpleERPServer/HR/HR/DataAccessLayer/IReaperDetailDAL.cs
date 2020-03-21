using Data.Entities.Credit;
using Shared.DataAccessLayer;
using Shared.Entities.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public interface IReaperDetailDAL : ICRUDOperationsDAL<ReaperDetail>
    {
        Task<IEnumerable<ReaperDetailDTO>> GetAllByReaperId(long reaperId);
    }
}
