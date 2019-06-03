using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DKBS.Domain
{
   public class PartnerCenterDescription
    {
        [Key]
        public int PartnerCenterDescription_Id { get; set; }
        public int PartnerId { get; set; }
        public string Rooms { get; set; }
        public string Capacity { get; set; }
        public string Facilities { get; set; }
        public string Activities { get; set; }
        public bool ApprovalStatus { get; set; }
        public string TextforQuotationforEmail { get; set; }
        public string Transportation { get; set; }
        public string Description { get; set; }
    }
}
