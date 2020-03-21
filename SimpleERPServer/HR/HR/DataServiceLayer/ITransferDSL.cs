using Shared.DataServiceLayer;
using Shared.Entities.Credit;
using Shared.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataServiceLayer
{
    public interface ITransferDSL : ICRUDOperationsDSL<TransferDTO>
    {
        Task<Response> GetAllByDriverId(long driverId, DataSource dataSource);
    }
}
