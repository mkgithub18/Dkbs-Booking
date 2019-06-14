using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
    public class SRInternalNotesDTO
    {
        [Key]
        public int? InternalNoteID { get; set; }

        public string InternalNoteName { get; set; }

        public string BookingID { get; set; }

        public string Notes { get; set; }

        public int? InternalNoteNotify { get; set; }

        public bool? ScheduleAction { get; set; }

        public bool? CopyToCloseRemark { get; set; }

        public DateTime PlannedStart { get; set; }

        public DateTime PlannedEnd { get; set; }

        public string toMessage { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBY { get; set; }

        public int? SharepointID { get; set; }
    }
}
