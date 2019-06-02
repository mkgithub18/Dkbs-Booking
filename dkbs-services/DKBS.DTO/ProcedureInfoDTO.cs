namespace DKBS.DTO
{
    public class ProcedureInfoDTO
    {
        public int ProcedureInfoId { get; set; }
        public ProcedureDTO ProcedureDTO  { get; set; }
        public PartnerDTO PartnerDTO { get; set; }
        //public CenterTypeDTO CenterTypeDTO { get; set; }
        public string EmailOffer { get; set; }
        public string Reply { get; set; }
        public string Comment { get; set; }
        public string Price { get; set; }
        public string Chat { get; set; }
    }    
}