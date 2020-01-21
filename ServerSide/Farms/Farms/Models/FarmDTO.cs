using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farms.Models
{
    public class FarmDTO : PageSettingModel
    {
        public long Id { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobile { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public virtual IEnumerable<ExportDTO> Exports { get; set; }
    }
}
