using System;

namespace DKBS.Domain
{
    public class Procedure
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
       // public CauseOfRemoval CauseOfRemoval { get; set; }
        //public ProcedureReviewType ProcedureReviewType { get; set; }
          // public Booking Booking { get; set; }
        //public Partner Partner { get; set; }
      //  public Customer Customer { get; set; }
         public int CauseOfRemovalId { get; set; }
         public int ProcedureReviewTypeId { get; set; }
         public int BookingId { get; set; }
        public int PartnerEmployeeId { get; set; }
        public int PartnerId { get; set; }
         public int CustomerId { get; set; }
        public int SRCommunicationId { get; set; }
        public int ContactId { get; set; }
        public int ProcedureCancelReasonId { get; set; }
        public int ProcedureReplyId { get; set; }
        public int UsedInEmailOffer { get; set; }
        public int TurnOffNotification { get; set; }
        public int ProcedureSharePointId { get; set; }
        public string IndustryCode { get; set; }
        public int ProcedureStatusId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}