using System;

namespace DKBS.DTO
{
    public class BookingArrangementTypeDTO
    {
        public int BookingArrangementTypeId { get; set; }
        public int BookingId { get; set; }
        public int ServiceCatalogId { get; set; }
        public int NumberOfParticipants { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
    }   
}