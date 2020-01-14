using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class CaseImporter
    {
        public int CaseImporterId { get; set; }
        public int ImporterId { get; set; }
        public int CaseId { get; set; }
    }
}
