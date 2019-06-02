using System;

namespace DKBS.DTO
{
    public class BookingAlternativeServiceDTO
    {
        public int BookingAlternativeServiceId { get; set; }
        public int BookingId { get; set; }
        public int NumberOfPieces { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifieddBy { get; set; }
    }
       
}