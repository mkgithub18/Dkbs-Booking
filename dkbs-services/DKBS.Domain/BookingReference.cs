namespace DKBS.Domain
{
    public class BookingReference
    {
        public int BookingReferenceId { get; set; }
        public Booking Booking { get; set; }
        public ContactPerson ContactPerson { get; set; }
        public string Other { get; set; }
        public LeadOfOrigin LeadOfOrigin { get; set; }
    }      
}