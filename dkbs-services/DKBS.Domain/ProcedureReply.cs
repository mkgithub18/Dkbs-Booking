using System;

namespace DKBS.Domain
{
    public class ProcedureReply
    {
        public int ProcedureReplyId { get; set; }
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDBy { get; set; }
    }
}
