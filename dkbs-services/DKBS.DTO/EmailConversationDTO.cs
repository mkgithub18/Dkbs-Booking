using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.DTO
{
    public class EmailConversationDTO
    {
        [Key]
        public int? EmailConversationID { get; set; }

        public int CRMPartnerId { get; set; }

        public string EmailTitle { get; set; }

        public string Message { get; set; }

        public string Sender { get; set; }

        public string CC_adresses { get; set; }

        public string Booking_ID { get; set; }

        public string Message_id { get; set; }

        public string to_Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBY { get; set; }

        public int? Sharepoint_ID { get; set; }
    }
}
