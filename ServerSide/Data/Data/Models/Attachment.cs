using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Attachment
    {
        public int AttachmentId { get; set; }
        public int DocumentId { get; set; }
        public string AttachmentName { get; set; }
        public string FolderName { get; set; }

        public virtual Document Document { get; set; }
    }
}
