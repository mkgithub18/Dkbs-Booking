using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Domain
{


    public class ChatCommunication
    {
        [Key]
        public int? Chat_ID { get; set; }

        public string ChatTitle { get; set; }

        public string Booking_ID { get; set; }

        public string Communications { get; set; }

        public string From_MyIT { get; set; }

        public string Copy_to_close_remark { get; set; }

        public int? Procedure_ID { get; set; }

        public bool? IsPartnerSideCommunication { get; set; }

        public bool? Procedure_info_communication { get; set; }

        public string Message_id { get; set; }

        public string to_Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBY { get; set; }

        public int? Sharepoint_ID { get; set; }



    }

}
