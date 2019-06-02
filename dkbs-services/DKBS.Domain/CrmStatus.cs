using System;

namespace DKBS.Domain
{
    public class CrmStatus
    {
        public int CrmStatusId { get; set; }
        public string CrmStatusTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}