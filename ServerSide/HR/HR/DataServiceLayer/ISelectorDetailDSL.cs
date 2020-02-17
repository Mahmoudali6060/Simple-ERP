using Shared.DataServiceLayer;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using System.Threading.Tasks;

namespace Clients.DataServiceLayer
{
    public interface ISelectorDetailDSL : ICRUDOperationsDSL<SelectorDetailDTO>
    {
        Task<Response> GetAllBySelectorId(long selectorId, DataSource dataSource);
    }
}
