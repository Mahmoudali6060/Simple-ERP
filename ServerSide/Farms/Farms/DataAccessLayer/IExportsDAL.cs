


using Data.Entities;
using Shared.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farms.DataAccessLayer
{
    public interface IExportDAL : ICRUDOperationsDAL<Export>
    {
        Task<IEnumerable<Export>> GetExportsByFarmId(long farmId);
    }
}
