using System;

namespace DKBS.Domain
{
    public class PartnerType
    {
        public int PartnerTypeId { get; set; }
        public string PartnerTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}