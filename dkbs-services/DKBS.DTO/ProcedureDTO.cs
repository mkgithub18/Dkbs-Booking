using System;

namespace DKBS.DTO
{
    public class ProcedureDTO
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public CauseOfRemovalDTO CauseOfRemovalDTO { get; set; }
        public ProcedureReviewTypeDTO ProcedureReviewTypeDTO { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        //public BookingDTO BookingDTO { get; set; }
        //public PartnerDTO PartnerDTO { get; set; }       
    }
}