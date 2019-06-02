using System;

namespace DKBS.DTO
{
    public class BookingRoomDTO
    {
        public int BookingRoomId { get; set; }
        public int BookingId { get; set; }
        public int TableSetId { get; set; }
        public string LocationAttraction { get; set; }
        public int NumberOfRooms { get; set; }
        public int PerPerson { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
    }
}