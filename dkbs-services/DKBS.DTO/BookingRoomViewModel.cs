using System;

namespace DKBS.DTO
{
    public class BookingRoomViewModel
    {
        public TableSetViewModel TableSetViewModel { get; set; }
        public string LocationAttraction { get; set; }
        public int NumberOfRooms { get; set; }
        public int PerPerson { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
    }
}