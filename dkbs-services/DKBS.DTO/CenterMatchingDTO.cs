using System;

namespace DKBS.DTO
{
    public class CenterMatchingDTO
    {
        public int CenterMatchingId { get; set; }
        public string MatchingCenter { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}