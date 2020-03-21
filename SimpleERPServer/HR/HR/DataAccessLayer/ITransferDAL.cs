using Data.Entities.Credit;
using Shared.DataAccessLayer;
using Shared.Entities.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.DataAccessLayer
{
    public interface ITransferDAL : ICRUDOperationsDAL<Transfer>
    {
        new Task<IEnumerable<TransferDTO>> GetAll();
        Task<IEnumerable<TransferDTO>> GetAllByDriverId(long driverId);
    }
}
