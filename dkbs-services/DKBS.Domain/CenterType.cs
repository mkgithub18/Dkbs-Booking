using System;

namespace DKBS.Domain
{
    public class CenterType
    {
        public int CenterTypeId { get; set; }
        public string CenterTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}