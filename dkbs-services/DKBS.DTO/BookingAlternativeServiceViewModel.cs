using System;

namespace DKBS.DTO
{
    public class BookingAlternativeServiceViewModel
    {
        public int NumberOfPieces { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}