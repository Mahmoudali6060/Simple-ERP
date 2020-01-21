using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.Models
{
    public class StationDTO : PageSettingModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OwnerMobile { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<IncomeDTO> Incomes { get; set; }
    }
}
