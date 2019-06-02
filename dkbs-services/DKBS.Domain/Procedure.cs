using System;

namespace DKBS.Domain
{
    public class Procedure
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
       // public CauseOfRemoval CauseOfRemoval { get; set; }
        //public ProcedureReviewType ProcedureReviewType { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
       // public Booking Booking { get; set; }
        //public Partner Partner { get; set; }
      //  public Customer Customer { get; set; }
         public int CauseOfRemovalId { get; set; }
         public int ProcedureReviewTypeId { get; set; }
         public int BookingId { get; set; }
         public int PartnerId { get; set; }
         public int CustomerId { get; set; }
    }
}