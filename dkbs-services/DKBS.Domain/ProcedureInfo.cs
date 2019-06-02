namespace DKBS.Domain
{
    public class ProcedureInfo
    {
        public int ProcedureInfoId { get; set; }
        //public Procedure Procedure { get; set; }
        public int ProcedureId { get; set; }
       // public Partner Partner { get; set; }
        public int PartnerId { get; set; }
       // public CenterType CenterType { get; set; }
        public int CenterTypeId { get; set; }
        public string EmailOffer { get; set; }
        public string Reply { get; set; }
        public string Comment { get; set; }
        public string Price { get; set; }
        public string Chat { get; set; }
    }    
}