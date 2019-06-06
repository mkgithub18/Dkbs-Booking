using System;
using System.ComponentModel.DataAnnotations;

namespace DKBS.DTO
{
    public class PartnerDTO
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string EmailId { get; set; }
        public CenterTypeDTO CenterTypeDTO { get; set; }
        public PartnerTypeDTO PartnerTypeDTO { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }



    public class CRMPartnerDTO
    {
        public string AccountId { get; set; }
        public string Partnertype { get; set; }
        public string MembershipType { get; set; }
        [Required]
        public string PartnerName { get; set; }
        public string CVR { get; set; }
        public string Telefon { get; set; }
        public string Centertype { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string PostNumber { get; set; }
        public string Land { get; set; }
        public bool StateAgreement { get; set; }
        public string Debitornummer { get; set; }
        public string Debitornummer2 { get; set; }
        public string Regions { get; set; }
        public DateTime? MembershipStartDate { get; set; }
        public string PublicURL { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PanoramView { get; set; }
        public bool RecommandedNPGRT60 { get; set; }
        public bool QualityAssuredNPSGRD30 { get; set; }

    }

}