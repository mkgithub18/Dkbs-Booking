using System;

namespace DKBS.DTO
{
    public class LandDTO
    {
        public int LandId { get; set; }
        public string LandTitle { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}