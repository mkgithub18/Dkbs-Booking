namespace DKBS.DTO
{
    public class BookingRegionDTO
    {
        public int BookingRegionId { get; set; }
        public BookingDTO BookingDTO { get; set; }
        public RegionDTO RegionDTO { get; set; }
    }
}