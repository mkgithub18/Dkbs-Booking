using System;

namespace DKBS.DTO
{
    public class BookingAndStatusDTO
    {
        public int BookingAndStatusId { get; set; }
        public string BookingerIncidentTitle { get; set; }
        public bool SLACount { get; set; }
        public bool ClosedStatus { get; set; }
        public string InformUserByEmail { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
