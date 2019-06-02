using System;

namespace DKBS.DTO
{
    public class PurposeDTO
    {
        public int PurposeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PurposeName { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}