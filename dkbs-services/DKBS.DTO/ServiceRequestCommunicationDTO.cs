using System;

namespace DKBS.DTO
{
    public class ServiceRequestCommunicationDTO
    {
        public int ServiceRequestCommunicationId { get; set; }
        public string SRCTitle { get; set; }
        public BookingDTO BookingDTO { get; set; }
        public string Communications { get; set; }
        public string FromMyIT { get; set; }
        public string CopyToCloseRemark { get; set; }
        public ProcedureDTO ProcedureDTO { get; set; }
        public string IsPartnerSideCommunication { get; set; }
        public string ProcedureInfoCommunication { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBY { get; set; }

    }
}
