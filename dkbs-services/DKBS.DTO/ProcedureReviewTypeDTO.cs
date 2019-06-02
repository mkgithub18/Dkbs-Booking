using System;

namespace DKBS.DTO
{
    public class ProcedureReviewTypeDTO
    {
        public int ProcedureReviewTypeId { get; set; }
        public string ProcedureReviewTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}