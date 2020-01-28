using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities.Credit
{
    public class ReaperDTO : BaseEntity
    {
        public string HeadName { get; set; }
        public string Balance { get; set; }
        public virtual IEnumerable<ReaperDetailDTO> ReaperDetails { get; set; }
    }
}
