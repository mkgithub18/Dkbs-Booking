using System;

namespace DKBS.DTO
{
    public class CenterTypeDTO
    {
        public int CenterTypeId { get; set; }
        public string CenterTypeTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}