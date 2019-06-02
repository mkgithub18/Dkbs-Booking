using System;

namespace DKBS.DTO
{
    public class RefreshmentsDTO
    {
        public int RefreshmentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
