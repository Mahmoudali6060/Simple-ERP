using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CaseForeignExporter
    {
        public int CaseForeignExporterId { get; set; }
        public int CaseId { get; set; }
        public int ForeignExporterId { get; set; }
    }
}
