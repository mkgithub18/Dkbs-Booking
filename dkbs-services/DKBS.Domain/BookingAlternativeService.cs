using System;

namespace DKBS.Domain
{
    public class BookingAlternativeService
    {
        public int BookingAlternativeServiceId { get; set; }
        public int BookingId { get; set; }
        public int NumberOfPieces { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public Booking Booking { get; set; }
        public DateTime? LastModified { get; set; }
    }

}