﻿using Shared.DataServiceLayer;
using Shared.Entities;
using Shared.Entities.Credit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.DataServiceLayer
{
    public interface IDriverAccountDSL : ICRUDOperationsDSL<DriverAccountDTO>
    {
        Task<Response> GetAllByDriverId(long driverId, DataSource dataSource);
    }
}
