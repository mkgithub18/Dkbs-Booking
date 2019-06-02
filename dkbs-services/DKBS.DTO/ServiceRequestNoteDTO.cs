using System;

namespace DKBS.DTO
{
    public class ServiceRequestNoteDTO
    {
        public int ServiceRequestNoteId { get; set; }
        public string SRNotesTitle { get; set; }
        public BookingDTO BookingDTO { get; set; }
        public string Action { get; set; }
        public string PlannedStart { get; set; }
        public string PlannedEnd { get; set; }
        public string CopyToCloseRemark { get; set; }
        public string ScheduleAction { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
    }
}
