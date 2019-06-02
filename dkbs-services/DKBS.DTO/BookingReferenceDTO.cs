namespace DKBS.DTO
{
    public class BookingReferenceDTO
    {
        public int BookingReferenceId { get; set; }
        public BookingDTO BookingDTO  { get; set; }
        public ContactPersonDTO ContactPersonDTO { get; set; }
        public string Other { get; set; }
        public LeadOfOriginDTO LeadOfOriginDTO { get; set; }
    }      
}