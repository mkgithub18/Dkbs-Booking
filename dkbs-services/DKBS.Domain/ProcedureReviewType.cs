using System;

namespace DKBS.Domain
{
    public class ProcedureReviewType
    {
        public int ProcedureReviewTypeId { get; set; }
        public string ProcedureReviewTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}