using System;

namespace DKBS.Domain
{
    public class BookingRoom
    {
        public int BookingRoomId { get; set; }

        public int BookingId { get; set; }
        public TableSet TableSet { get; set; }
        public string LocationAttraction { get; set; }
        public int NumberOfRooms { get; set; }
        public int PerPerson { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public Booking Booking { get; set; }
    }
}