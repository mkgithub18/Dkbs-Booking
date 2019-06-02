using System;

namespace DKBS.DTO
{
    public class BookingArrangementTypeViewModel
    {
        public int ServiceCatalogId { get; set; }
        public int NumberOfParticipants { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }
    }
}