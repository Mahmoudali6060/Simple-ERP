using System;
using System.Collections.Generic;
using System.Text;
using Shared.Interfaces;

namespace Shared.Entities
{
  public  class BaseEntitiy :IIDInterface
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
