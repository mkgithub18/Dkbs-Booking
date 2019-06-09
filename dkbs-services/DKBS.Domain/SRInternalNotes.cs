using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Domain
{
    public class SRInternalNotes
    {
        [Key]
        public int? InternalNote_ID { get; set; }

        public string InternalNoteName { get; set; }

        public string Booking_ID { get; set; }

        public string Notes { get; set; }

        public int? InternalNoteNotify { get; set; }

        public bool? Schedule_action { get; set; }

        public bool? Copy_to_close_remark { get; set; }

        public DateTime Planned_start { get; set; }

        public DateTime Planned_end { get; set; }

        public string to_Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBY { get; set; }

        public int? Sharepoint_ID { get; set; }
       

    }

}
