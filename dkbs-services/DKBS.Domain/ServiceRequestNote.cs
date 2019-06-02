using System;

namespace DKBS.Domain
{
    public class ServiceRequestNote
    {
        public int ServiceRequestNoteId { get; set; }
        public string SRNotesTitle { get; set; }
        public Booking Booking { get; set; }
        public string Action { get; set; }
        public string PlannedStart { get; set; }
        public string PlannedEnd { get; set; }
        public string CopyToCloseRemark { get; set; }
        public string ScheduleAction { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
