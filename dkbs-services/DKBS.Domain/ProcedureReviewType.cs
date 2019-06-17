using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.Domain
{
    public class ProcedureReviewType
    {
        [Key]
        public int ProcedureReviewTypeId { get; set; }
        public string ProcedureReviewTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}