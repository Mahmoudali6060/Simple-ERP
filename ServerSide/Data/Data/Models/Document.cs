using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Document
    {
        public Document()
        {
            Attachment = new HashSet<Attachment>();
        }

        public int DocumentId { get; set; }
        public int CaseId { get; set; }
        public int StructureId { get; set; }
        public string CodeReference { get; set; }
        public int SectionNo { get; set; }
        public int SubSectionNo { get; set; }
        public int DocNo { get; set; }
        public int IngoingNo { get; set; }
        public int OutGoingNo { get; set; }
        public DateTime SendingDate { get; set; }
        public string ToWhome { get; set; }
        public string FromWhome { get; set; }
        public int SectorId { get; set; }
        public int NoOfAttachments { get; set; }
        public string SubjectEn { get; set; }
        public string SubjectAr { get; set; }
        public bool Confidential { get; set; }
        public int DocumentLanguageId { get; set; }
        public int SendingMethodId { get; set; }
        public string CommentEn { get; set; }
        public string CommentAr { get; set; }

        public virtual Cases Case { get; set; }
        public virtual Structure Structure { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
    }
}
