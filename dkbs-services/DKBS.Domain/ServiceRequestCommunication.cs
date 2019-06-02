using System;

namespace DKBS.Domain
{
    public class ServiceRequestCommunication
    {
        public int ServiceRequestCommunicationId { get; set; }
        public string SRCTitle { get; set; }
        public Booking Booking { get; set; }
        public string Communications { get; set; }
        public string FromMyIT { get; set; }
        public string CopyToCloseRemark { get; set; }
        public Procedure Procedure { get; set; }
        public string IsPartnerSideCommunication { get; set; }
        public string ProcedureInfoCommunication { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }
             
    }
}
