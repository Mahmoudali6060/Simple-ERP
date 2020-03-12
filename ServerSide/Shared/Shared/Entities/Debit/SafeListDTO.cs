using Data.Entities.Debit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Debit
{
    public class SafeListDTO
    {
        public decimal IncomingTotal { get; set; }
        public decimal OutcomingTotal { get; set; }
    }
}
