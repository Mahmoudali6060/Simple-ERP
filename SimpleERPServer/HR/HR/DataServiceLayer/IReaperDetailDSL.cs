using Shared.DataServiceLayer;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using System.Threading.Tasks;

namespace Clients.DataServiceLayer
{
    public interface IReaperDetailDSL : ICRUDOperationsDSL<ReaperDetailDTO>
    {
        Task<Response> GetAllByReaperId(long reaperId, DataSource dataSource);
    }
}
