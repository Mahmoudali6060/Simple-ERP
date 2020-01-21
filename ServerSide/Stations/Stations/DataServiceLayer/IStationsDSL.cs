using Stations.Models;
using Shared.DataServiceLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stations.DataServiceLayer
{
    public interface IStationDSL : ICRUDOperationsDSL<StationDTO>
    {

    }
}
