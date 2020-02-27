


using Data.Entities.Credit;
using Shared.DataAccessLayer;
using Shared.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public interface IDriverAccountDAL : ICRUDOperationsDAL<DriverAccount>
    {
        Task<IEnumerable<DriverAccount>> GetAllByDriverId(long sriverId);
    }
}
