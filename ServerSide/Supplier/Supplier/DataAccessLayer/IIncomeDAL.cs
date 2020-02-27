


using Data.Entities.Credit;
using Shared.DataAccessLayer;
using Shared.Entities.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supplier.DataAccessLayer
{
    public interface IIncomeDAL : ICRUDOperationsDAL<Income>
    {
        Task<IEnumerable<IncomeDTO>> GetIncomesByFarmId(long farmId);
        new Task<IEnumerable<IncomeDTO>> GetAll();
    }
}
