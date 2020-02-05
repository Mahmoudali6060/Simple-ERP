using Shared.DataServiceLayer;
using Shared.Entities;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clients.DataServiceLayer
{
    public interface IOutcomeDSL : ICRUDOperationsDSL<OutcomeDTO>
    {
        Task<ResponseEntityList<OutcomeDTO>> GetOutcomesByStationId(long stationId);

    }
}
