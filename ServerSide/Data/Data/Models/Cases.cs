using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Cases
    {
        public Cases()
        {
            CaseEmbassy = new HashSet<CaseEmbassy>();
            Document = new HashSet<Document>();
        }

        public int CaseId { get; set; }
        public int StructureId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public DateTime Date { get; set; }
        public int CaseStageId { get; set; }
        public int CaseTypeId { get; set; }
        public bool CaseStatus { get; set; }
        public int DomesticIndustryId { get; set; }
        public int ActionTakenId { get; set; }
        public int GovernmentId { get; set; }

        public virtual ActionTaken ActionTaken { get; set; }
        public virtual CaseStage CaseStage { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual DomesticIndustry DomesticIndustry { get; set; }
        public virtual Government Government { get; set; }
        public virtual Structure Structure { get; set; }
        public virtual ICollection<CaseEmbassy> CaseEmbassy { get; set; }
        public virtual ICollection<Document> Document { get; set; }
    }
}
