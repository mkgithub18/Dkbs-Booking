using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Domain
{
   public class GetWebsitePartnerList
    {
        public int? CRMPartnerId { get; set; }
        public string CVR { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostNumber { get; set; }
        public string Regions { get; set; }
        public string Land { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string PanoramView { get; set; }
        public string PublicURL { get; set; }
        public string Centertype { get; set; }
        public bool RecommandedNPGRT60 { get; set; }
        public bool QualityAssuredNPSGRD30 { get; set; }
        public string Partnertype { get; set; }
        public DateTime LastModified { get; set; }

    }
}
