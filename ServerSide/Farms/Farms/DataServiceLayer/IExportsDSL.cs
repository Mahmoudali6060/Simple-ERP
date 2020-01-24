using Farms.Models;
using Shared.DataServiceLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farms.DataServiceLayer
{
    public interface IExportDSL : ICRUDOperationsDSL<ExportDTO>
    {
        Task<ResponseEntityList<ExportDTO>> GetExportsByFarmId(long farmId);
    }
}
